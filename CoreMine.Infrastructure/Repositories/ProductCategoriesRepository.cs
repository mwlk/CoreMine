using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.Data;
using CoreMine.Entities;

namespace CoreMine.Infrastructure.Repositories
{
    public class ProductCategoriesRepository : IProductCategoriesRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductCategory entityToAdd, CancellationToken cancellationToken)
        {
            await _context.ProductCategories.AddAsync(entityToAdd, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(ProductCategory entityToEdit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductCategory>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        
    }
}
