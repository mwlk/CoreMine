using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.Data;
using CoreMine.Entities;

namespace CoreMine.Infraestructure.Repositories
{
    public class StockLevelsRepository : IStockLevelsRepository
    {
        private readonly AppDbContext _context;

        public StockLevelsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StockLevel entityToAdd, CancellationToken cancellationToken)
        {
            await _context.StockLevels.AddAsync(entityToAdd, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(StockLevel entityToEdit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StockLevel>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StockLevel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
