using MediatR;
using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.ApplicationBusiness.UseCases.Categories.Commands;
using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.UseCases.Categories.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoriesRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CreateCategoryHandler(ICategoriesRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = new Category
            {
                Name = request.Name,
                Code = request.Code,
                ParentId = request.ParentId,
            };

            await repository.AddAsync(newCategory, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return newCategory.Id;
        }
    }
}
