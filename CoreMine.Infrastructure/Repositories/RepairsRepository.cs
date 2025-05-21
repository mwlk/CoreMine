using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.Data;
using CoreMine.Entities;

namespace CoreMine.Infraestructure.Repositories
{
    public class RepairsRepository : IRepairsRepository
    {
        private readonly AppDbContext _context;

        public RepairsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Repair entityToAdd, CancellationToken cancellationToken)
        {
            await _context.Repairs.AddAsync(entityToAdd, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Repair entityToEdit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Repair>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Repair> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
