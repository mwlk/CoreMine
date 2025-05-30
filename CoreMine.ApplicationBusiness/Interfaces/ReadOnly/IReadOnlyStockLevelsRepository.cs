using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyStockLevelsRepository
    {
        IQueryable<StockLevel> GetQueryable();
    }
}
