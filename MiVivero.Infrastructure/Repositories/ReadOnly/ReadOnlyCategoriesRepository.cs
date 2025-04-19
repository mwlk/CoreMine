using Microsoft.EntityFrameworkCore;
using MiVivero.ApplicationBusiness.Interfaces.ReadOnly;
using MiVivero.Data;
using MiVivero.Data.ReadModels;
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

        public IQueryable<CategoryWithHierarchyReadModel> GetQueryable()
        {
            return _context.Set<CategoryWithHierarchyReadModel>()
                .AsNoTracking()
                .AsQueryable();
        }
    }
}
