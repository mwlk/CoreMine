using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyProductStateTypesRepository
    {
        IQueryable<ProductStateType> GetQueryable();
    }
}
