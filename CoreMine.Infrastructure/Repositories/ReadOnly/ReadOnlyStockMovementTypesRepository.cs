using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyStockMovementTypesRepository : IReadOnlyStockMovementTypesRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyStockMovementTypesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<StockMovementType> GetQueryable()
        {
            return _context.StockMovementTypes
                .AsQueryable()
                .AsNoTracking();
        }
    }
}
