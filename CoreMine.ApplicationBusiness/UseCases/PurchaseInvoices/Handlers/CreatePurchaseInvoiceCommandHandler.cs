using CoreMine.ApplicationBusiness.Exceptions;
using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.PurchaseInvoices.Commands;
using CoreMine.Entities;
using CoreMine.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.ApplicationBusiness.UseCases.PurchaseInvoices.Handlers
{
    public class CreatePurchaseInvoiceCommandHandler : ICommandHandler<CreatePurchaseInvoiceCommand, int>
    {
        private readonly IPurchaseInvoicesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadOnlyProductsRepository _productsRepository;
        private readonly IReadOnlyStockRepository _readOnlyStockRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IStockMovementsRepository _stockMovementsRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreatePurchaseInvoiceCommandHandler(IPurchaseInvoicesRepository repository, IUnitOfWork unitOfWork, IReadOnlyProductsRepository productsRepository, IReadOnlyStockRepository readOnlyStockRepository, IStockRepository stockRepository, IDateTimeProvider dateTimeProvider, IStockMovementsRepository stockMovementsRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _productsRepository = productsRepository;
            _readOnlyStockRepository = readOnlyStockRepository;
            _stockRepository = stockRepository;
            _dateTimeProvider = dateTimeProvider;
            _stockMovementsRepository = stockMovementsRepository;
        }

        public async Task<int> HandleAsync(CreatePurchaseInvoiceCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // DEBUG - ver qué fecha está llegando
            Console.WriteLine($"IngresedAt recibido: '{command.IngresedAt}'");
            Console.WriteLine($"IngresedAt ticks: {command.IngresedAt.Ticks}");
            Console.WriteLine($"DateTime.MinValue ticks: {DateTime.MinValue.Ticks}");
            Console.WriteLine($"Es MinValue?: {command.IngresedAt == DateTime.MinValue}");

            var productCodes = command.Products
                .Select(p => p.ProductCode)
                .Distinct()
                .ToList();

            var productIdsMap = await _productsRepository.GetProductIdsByCodesAsync(productCodes, cancellationToken);

            var notFound = productCodes.Except(productIdsMap.Keys).ToList();

            if (notFound.Any())
            {
                throw new ProductsNotFoundException(string.Join(",", notFound));
            }

            var productStockDict = await _readOnlyStockRepository.GetQueryable()
                .Where(p => productIdsMap.Select(p => p.Value).Contains(p.ProductId)
                        && (p.LocationId == command.LocationId))
                .ToDictionaryAsync(p => p.ProductId, cancellationToken);

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {

                foreach (var item in command.Products)
                {
                    var productId = productIdsMap[item.ProductCode];

                    if (productStockDict.TryGetValue(productId, out var productStock))
                    {
                        productStock.Quantity += item.Quantity;
                        await _stockRepository.EditAsync(productStock, cancellationToken);
                    }
                    else
                    {
                        var newStock = new Stock
                        {
                            ProductId = productId,
                            LocationId = command.LocationId,
                            Quantity = item.Quantity,
                            UpdatedAt = _dateTimeProvider.UtcNow,
                        };

                        await _stockRepository.AddAsync(newStock, cancellationToken);
                    }

                    var movement = new StockMovement
                    {
                        ProductId = productId,
                        LocationId = command.LocationId,
                        CreatedAt = _dateTimeProvider.UtcNow,
                        Quantity = item.Quantity,
                        StockMovementTypeId = (int)StockMovementTypeEnum.Ingress,
                        Observations = $"Factura Nro: {command.InvoiceNumber}"
                    };

                    await _stockMovementsRepository.AddAsync(movement, cancellationToken);
                }

                var invoiceDetails = command.Products.Select(p => new PurchaseInvoiceDetail
                {
                    ProductId = productIdsMap[p.ProductCode],
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                }).ToList();

                var entityToAdd = new PurchaseInvoice
                {
                    SupplierId = command.SupplierId,
                    InvoiceNumber = command.InvoiceNumber,
                    IngresedAt = command.IngresedAt,
                    PurchaseInvoiceDetails = invoiceDetails,
                };

                await _repository.AddAsync(entityToAdd, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return entityToAdd.Id;
            }
            catch (Exception)
            {

                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
