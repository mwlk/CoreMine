using CoreMine.Data.ReadModels;
using CoreMine.Entities;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyCategoriesRepository
    {
        IQueryable<CategoryWithFullCodeReadModel> GetQueryable();
    }
}
