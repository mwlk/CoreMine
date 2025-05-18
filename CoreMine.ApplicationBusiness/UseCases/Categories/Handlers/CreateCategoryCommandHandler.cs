using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Categories.Commands;
using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.UseCases.Categories.Handlers
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoriesRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CreateCategoryCommandHandler(ICategoriesRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> HandleAsync(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var newCategory = new ProductCategory
            {
                Name = command.Name,
                Code = command.Code,
                ParentId = command.ParentId,
            };

            await repository.AddAsync(newCategory, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return newCategory.Id;
        }
    }
}
