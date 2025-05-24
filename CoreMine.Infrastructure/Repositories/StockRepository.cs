using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Stock entityToAdd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(Stock entityToEdit, CancellationToken cancellationToken)
        {
            var entityDb = await _context.Stocks.FirstOrDefaultAsync(p => p.Id == entityToEdit.Id, cancellationToken);

            if (entityDb == null)
            {
                return;
            }

            entityDb.Quantity = entityToEdit.Quantity;
        }

        public Task<IEnumerable<Stock>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
