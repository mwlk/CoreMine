using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyProductStateTypesRepository : IReadOnlyProductStateTypesRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyProductStateTypesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProductStateType> GetQueryable()
        {
            return _context.ProductStateTypes
                .AsQueryable()
                .AsNoTracking();
        }
    }
}
