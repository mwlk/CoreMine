using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.Data;
using CoreMine.Entities;

namespace CoreMine.Infraestructure.Repositories
{
    public class StockMovementsRepository : IStockMovementsRepository
    {
        private readonly AppDbContext _context;

        public StockMovementsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StockMovement entityToAdd, CancellationToken cancellationToken)
        {
            await _context.StockMovements.AddAsync(entityToAdd, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(StockMovement entityToEdit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StockMovement>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StockMovement> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
