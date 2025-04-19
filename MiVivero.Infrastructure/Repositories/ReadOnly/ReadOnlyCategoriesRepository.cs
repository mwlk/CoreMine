using MiVivero.ApplicationBusiness.Interfaces.ReadOnly;
using MiVivero.Data;
using MiVivero.Entities;

namespace MiVivero.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyCategoriesRepository : IReadOnlyCategoriesRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetQueryable()
        {
            return _context.Categories.AsQueryable();
        }
    }
}
