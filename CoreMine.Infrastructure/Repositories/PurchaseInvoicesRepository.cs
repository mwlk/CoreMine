using CoreMine.ApplicationBusiness.Interfaces;
using CoreMine.Data;
using CoreMine.Entities;

namespace CoreMine.Infraestructure.Repositories
{
    public class PurchaseInvoicesRepository : IPurchaseInvoicesRepository
    {
        private readonly AppDbContext _context;

        public PurchaseInvoicesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PurchaseInvoice entityToAdd, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entityToAdd, cancellationToken);
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(PurchaseInvoice entityToEdit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PurchaseInvoice>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseInvoice> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
