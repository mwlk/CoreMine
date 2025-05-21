using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Repairs.Commands;
using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.UseCases.Repairs.Handlers
{
    public class CreateRepairCommandHandler : ICommandHandler<CreateRepairCommand, int>
    {
        private readonly IRepairsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateRepairCommandHandler(IRepairsRepository repository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<int> HandleAsync(CreateRepairCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            // agregar validacion al command

            try
            {
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
                    StartDate = command.StartDate,
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
