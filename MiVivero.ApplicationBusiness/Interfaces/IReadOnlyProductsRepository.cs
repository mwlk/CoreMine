using MiVivero.Data.ReadModels;

namespace MiVivero.ApplicationBusiness.Interfaces
{
    public interface IReadOnlyProductsRepository
    {
        IQueryable<ProductWithCategoryReadModel> GetQueryable();
    }
}
