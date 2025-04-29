using CoreMine.Data.ReadModels;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyCategoriesRepository
    {
        IQueryable<CategoryWithHierarchyReadModel> GetQueryable();
    }
}
