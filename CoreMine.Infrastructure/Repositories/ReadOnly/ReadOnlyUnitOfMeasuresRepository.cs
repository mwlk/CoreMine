using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyUnitOfMeasuresRepository : IReadOnlyUnitOfMeasuresRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyUnitOfMeasuresRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<UnitOfMeasure> GetQueryable()
        {
            return _context.UnitOfMeasures
                .AsQueryable()
                .AsNoTracking();
        }
    }
}
