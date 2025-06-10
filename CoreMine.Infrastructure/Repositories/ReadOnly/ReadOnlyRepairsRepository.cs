using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Data.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyRepairsRepository : IReadOnlyRepairsRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyRepairsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<RepairWithProductsReadModel> GetQueryable()
        {
            return _context.RepairsWithProducts.AsNoTracking();
        }
    }
}
