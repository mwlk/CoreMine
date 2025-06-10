using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Suppliers.Commands;
using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.UseCases.Suppliers.Handlers
{
    public class CreateSupplierCommandHandler : ICommandHandler<CreateSupplierCommand, int>
    {
        private readonly ISuppliersRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateSupplierCommandHandler(ISuppliersRepository repository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<int> HandleAsync(CreateSupplierCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            command.Validate();

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var entityToAdd = new Supplier
                {
                    Name = command.Name,
                    Surname = command.Surname,
                    BusinessName = command.BusinessName,
                    TradeName = command.TradeName,
                    Contact = command.Contact,
                    Phone = command.Phone,
                    CreatedAt = _dateTimeProvider.UtcNow
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
