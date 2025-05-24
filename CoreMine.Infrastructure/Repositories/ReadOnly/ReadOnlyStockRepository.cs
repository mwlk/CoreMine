using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyStockRepository : IReadOnlyStockRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyStockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Stock?> GetByProductAndLocationAsync(int productId, int locationId, CancellationToken cancellationToken)
        {
            return await _context.Stocks
                .Where(p => p.ProductId == productId && p.LocationId == locationId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<Stock> GetQueryable()
        {
            return _context.Stocks.AsNoTracking();
        }
    }
}
