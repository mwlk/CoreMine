using CoreMine.Data;
using CoreMine.Data.ReadModels;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyProductsRepository : IReadOnlyProductsRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProductsWithFullCategoryInfoReadModel> GetQueryable()
        {
            return _context.ProductsWithFullCategoryInfo
                .AsNoTracking();
        }

        public async Task<Dictionary<string, int>> GetProductIdsByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(p => p.Code.Equals(p.Code))
                .ToDictionaryAsync(p => p.Code, p => p.Id, cancellationToken);
        }
    }
}
