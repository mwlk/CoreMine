using CoreMine.Data.ReadModels;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyRepairsRepository
    {
        IQueryable<RepairWithProductsReadModel> GetQueryable();
    }
}
