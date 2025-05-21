using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyMachinesRepository : IReadOnlyMachinesRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyMachinesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Machine> GetQueryable()
        {
            return _context.Machines
                .AsQueryable()
                .AsQueryable();
        }
    }
}
