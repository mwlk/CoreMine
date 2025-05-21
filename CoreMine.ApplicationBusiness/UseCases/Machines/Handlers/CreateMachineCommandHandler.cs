using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Machines.Commands;
using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.UseCases.Machines.Handlers
{
    public class CreateMachineCommandHandler : ICommandHandler<CreateMachineCommand, int>
    {
        private readonly IMachinesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateMachineCommandHandler(IMachinesRepository repository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<int> HandleAsync(CreateMachineCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            command.Validate();

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var entitytToAdd = new Machine
            {
                Code = command.Code,
                Description = command.Description,
                AcquisitionDate = _dateTimeProvider.UtcNow,
                IsActive = true
            };

            await _repository.AddAsync(entitytToAdd, cancellationToken);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            return entitytToAdd.Id;
        }
    }
}
