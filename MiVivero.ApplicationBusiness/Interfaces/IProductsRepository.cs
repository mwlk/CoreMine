using MiVivero.Entities;
using MiVivero.Models.Filters;

namespace MiVivero.ApplicationBusiness.Interfaces
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByFilterAsync(ProductFilter filter, CancellationToken cancellationToken);
    }
}
