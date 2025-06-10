using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyMachinesRepository
    {
        IQueryable<Machine> GetQueryable(); 
    }
}
