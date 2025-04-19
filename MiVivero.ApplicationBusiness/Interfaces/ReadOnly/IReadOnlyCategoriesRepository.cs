using MiVivero.Data.ReadModels;

namespace MiVivero.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyCategoriesRepository
    {
        IQueryable<CategoryWithHierarchyReadModel> GetQueryable();
    }
}
