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
    }
}
