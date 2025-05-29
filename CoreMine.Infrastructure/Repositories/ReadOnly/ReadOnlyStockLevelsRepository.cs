using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyStockLevelsRepository : IReadOnlyStockLevelsRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyStockLevelsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<StockLevel> GetQueryable()
        {
            return _context.StockLevels.AsNoTracking();
        }
    }
}
