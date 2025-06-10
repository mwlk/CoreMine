using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Products.Commands;
using CoreMine.Entities;
using CoreMine.Entities.Enums;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Handlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, int>
    {
        private readonly IProductsRepository _repository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductsRepository repository, IDateTimeProvider dateTimeProvider, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> HandleAsync(CreateProductCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            command.Validate();

            var entityToAdd = new Product
            {
                Name = command.Name,
                Code = command.Code,
                CategoryId = command.ProductCategoryId,
                CreatedAt = _dateTimeProvider.UtcNow,
                ModificatedAt = null,
                Description = command.Description,
                SupplierId = command.SupplierId,
                UnitOfMeasureId = command.UnitOfMeasureId,
                UnitPrice = command.UnitPrice,
                ProductStates = new List<ProductState>
                {
                    new ProductState
                    {
                        ProductStateTypeId = (int)ProductStateTypeEnum.Operational,
                        CreatedAt = _dateTimeProvider.UtcNow,
                        Observations = $"Producto Creado: {command.Code} | Dia: {_dateTimeProvider.UtcNow.Date.ToShortDateString()}"
                    }
                }
            };

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
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
