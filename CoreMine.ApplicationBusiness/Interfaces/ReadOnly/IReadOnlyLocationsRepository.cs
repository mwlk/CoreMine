using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyLocationsRepository
    {
        IQueryable<Location> GetQueryable();
    }
}
