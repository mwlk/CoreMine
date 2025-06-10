using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyPurchaseInvoicesRepository : IReadOnlyPurchaseInvoicesRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyPurchaseInvoicesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<PurchaseInvoice> GetQueryable()
        {
            return _context.PurchaseInvoices.AsNoTracking();
        }
    }
}
