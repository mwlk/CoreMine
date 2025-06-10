using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyStockMovementTypesRepository
    {
        IQueryable<StockMovementType> GetQueryable();
    }
}
