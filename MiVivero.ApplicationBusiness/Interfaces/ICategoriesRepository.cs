using MiVivero.Entities;
using MiVivero.Models.Filters;

namespace MiVivero.ApplicationBusiness.Interfaces
{
    public interface ICategoriesRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetByFilterAsync(CategoryFilter filter, CancellationToken cancellationToken);
    }
}
