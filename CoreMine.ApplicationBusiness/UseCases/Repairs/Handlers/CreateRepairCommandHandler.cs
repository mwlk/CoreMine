using CoreMine.ApplicationBusiness.Exceptions;
using CoreMine.ApplicationBusiness.Exceptions.Enums;
using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Repairs.Commands;
using CoreMine.Entities;
using CoreMine.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using static CoreMine.ApplicationBusiness.Exceptions.EntityNotFoundException;

namespace CoreMine.ApplicationBusiness.UseCases.Repairs.Handlers
{
    public class CreateRepairCommandHandler : ICommandHandler<CreateRepairCommand, int>
    {
        private readonly IRepairsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IReadOnlyLocationsRepository _readOnlyLocationsRepository;
        private readonly IReadOnlyProductsRepository _readOnlyProductsRepository;
        private readonly IReadOnlyStockRepository _readOnlyStockRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IStockMovementsRepository _stockMovementsRepository;
        private readonly IReadOnlyMachinesRepository _readOnlyMachinesRepository;

        public CreateRepairCommandHandler(IRepairsRepository repository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, IReadOnlyLocationsRepository readOnlyLocationsRepository, IReadOnlyProductsRepository readOnlyProductsRepository, IReadOnlyStockRepository readOnlyStockRepository, IStockRepository stockRepository, IStockMovementsRepository stockMovementsRepository, IReadOnlyMachinesRepository readOnlyMachinesRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _readOnlyLocationsRepository = readOnlyLocationsRepository;
            _readOnlyProductsRepository = readOnlyProductsRepository;
            _readOnlyStockRepository = readOnlyStockRepository;
            _stockRepository = stockRepository;
            _stockMovementsRepository = stockMovementsRepository;
            _readOnlyMachinesRepository = readOnlyMachinesRepository;
        }

        public async Task<int> HandleAsync(CreateRepairCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!command.Products.Any())
            {
                throw new Exception("Debe cargar productos para la reparación");
            }

            var maquineExist = await _readOnlyMachinesRepository.GetQueryable()
                .AnyAsync(p => p.Id == command.MachineId, cancellationToken);

            if (!maquineExist)
            {
                throw new EntityNotFoundException(command.MachineId, EntityNotFoundType.Machine);
            }

            var productIds = command.Products.Select(p => p.ProductId);

            var existingProductIds = await _readOnlyProductsRepository.GetQueryable()
                .Where(p => productIds.Contains(p.Id) && p.LastStateTypeId.Value == (int)ProductStateTypeEnum.Operational)
                .Select(p => p.Id)
                .ToListAsync(cancellationToken);

            var missingIds = productIds.Except(existingProductIds).ToList();

            if (missingIds.Any())
            {
                var firstMissing = missingIds.First();
                throw new EntityNotFoundException(firstMissing, EntityNotFoundType.Product);
            }


            if (command.LocationId.HasValue)
            {
                var location = await _readOnlyLocationsRepository.GetQueryable()
                    .FirstOrDefaultAsync(p => p.Id == command.LocationId, cancellationToken);

                if (location is null)
                {
                    throw new EntityNotFoundException(command.LocationId.Value, EntityNotFoundType.Location);
                }
            }

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var productStockDict = await _readOnlyStockRepository.GetQueryable()
                    .Where(p => productIds.Contains(p.ProductId) &&
                        (!command.LocationId.HasValue || p.LocationId == command.LocationId.Value))
                    .ToDictionaryAsync(p => p.ProductId, cancellationToken);


                foreach (var repairProduct in command.Products)
                {
                    if (!productStockDict.TryGetValue(repairProduct.ProductId, out var stock))
                    {
                        throw new EntityNotFoundException(repairProduct.ProductId, EntityNotFoundType.Stock);
                    }

                    if (stock.Quantity < repairProduct.QuantityUsed)
                    {
                        throw new InsufficientStockException($"No hay stock para el producto código: {repairProduct.ProductId}");
                    }

                    stock.Quantity -= repairProduct.QuantityUsed;

                    await _stockRepository.EditAsync(stock, cancellationToken);

                    var movement = new StockMovement
                    {
                        ProductId = repairProduct.ProductId,
                        Quantity = repairProduct.QuantityUsed,
                        StockMovementTypeId = (int)StockMovementTypeEnum.Used,
                        CreatedAt = _dateTimeProvider.UtcNow,
                        LocationId = command.LocationId.HasValue ? command.LocationId.Value : 1,
                        Observations = $"Reparacion para máquina {command.MachineId}"
                    };

                    await _stockMovementsRepository.AddAsync(movement, cancellationToken);
                }

                var entityToAdd = new Repair
                {
                    MachineId = command.MachineId,
                    Description = command.Description,
                    Observations = command.Observations,
                    RepairProducts = command.Products.Select(p => new RepairProduct
                    {
                        ProductId = p.ProductId,
                        QuantityUsed = p.QuantityUsed,
                    }).ToList(),
                    StartDate = command.StartDate.HasValue ? command.StartDate.Value : _dateTimeProvider.UtcNow,
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
