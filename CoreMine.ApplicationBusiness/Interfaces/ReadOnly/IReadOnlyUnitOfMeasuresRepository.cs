using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyUnitOfMeasuresRepository
    {
        IQueryable<UnitOfMeasure> GetQueryable();
    }
}
