using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyStockRepository
    {
        Task<Stock?> GetByProductAndLocationAsync(int productId, int locationId, CancellationToken cancellationToken);
        IQueryable<Stock> GetQueryable();
    }
}
