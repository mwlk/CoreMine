using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyLocationsRepository : IReadOnlyLocationsRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyLocationsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Location> GetQueryable()
        {
            return _context.Locations
                .AsQueryable()
                .AsNoTracking();
        }
    }
}
