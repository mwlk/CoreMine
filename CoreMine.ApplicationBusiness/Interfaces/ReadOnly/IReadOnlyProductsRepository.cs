using CoreMine.Data.ReadModels;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyProductsRepository
    {
        IQueryable<ProductsWithFullCategoryInfoReadModel> GetQueryable();
    }
}
