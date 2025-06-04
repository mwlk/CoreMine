using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyPurchaseInvoicesRepository
    {
        public IQueryable<PurchaseInvoice> GetQueryable();
    }
}
