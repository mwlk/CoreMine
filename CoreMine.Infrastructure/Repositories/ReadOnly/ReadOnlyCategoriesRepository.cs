using Microsoft.EntityFrameworkCore;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyCategoriesRepository : IReadOnlyCategoriesRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProductCategory> GetQueryable()
        {
            var query = _context.ProductCategories.AsQueryable().AsNoTracking();

            return query;
        }
    }
}
