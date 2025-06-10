using Microsoft.EntityFrameworkCore;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using CoreMine.Data.ReadModels;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyCategoriesRepository : IReadOnlyCategoriesRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<CategoryWithFullCodeReadModel> GetQueryable()
        {
            return _context.Categories
                .AsQueryable()
                .AsNoTracking();
        }
    }
}
