using MiVivero.Entities;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyCategoriesRepository
    {
        IQueryable<Category> GetQueryable();
    }
}
