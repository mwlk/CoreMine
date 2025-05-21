using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlySuppliersRepository
    {
        IQueryable<Supplier> GetQueryable();
    }
}
