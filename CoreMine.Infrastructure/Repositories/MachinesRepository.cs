using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.Data;
using CoreMine.Entities;

namespace CoreMine.Infraestructure.Repositories
{
    public class MachinesRepository : IMachinesRepository
    {
        private readonly AppDbContext _context;

        public MachinesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Machine entityToAdd, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entityToAdd, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Machine entityToEdit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Machine>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Machine> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
