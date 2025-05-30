using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.StockLevels.Commands;
using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.UseCases.StockLevels.Handlers
{
    public class CreateStockLevelCommandHandler : ICommandHandler<CreateStockLevelCommand, int>
    {
        private readonly IStockLevelsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateStockLevelCommandHandler(IStockLevelsRepository repository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<int> HandleAsync(CreateStockLevelCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            command.Validate();

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var entityToAdd = new StockLevel
                {
                    LocationId = command.LocationId,
                    ProductId = command.ProductId,
                    DefinedAt = _dateTimeProvider.UtcNow,
                    MaxQuantity = command.MaxQuantity,
                    MinQuantity = command.MinQuantity
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
