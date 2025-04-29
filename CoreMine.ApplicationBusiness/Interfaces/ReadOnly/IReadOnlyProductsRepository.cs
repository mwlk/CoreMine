using CoreMine.Data.ReadModels;

namespace CoreMine.ApplicationBusiness.Interfaces.ReadOnly
{
    public interface IReadOnlyProductsRepository
    {
        Task<(int TotalCount, List<ProductWithCategoryReadModel> Rows)>GetProductsByHierarchyAsync
            (string? name, string ancestorIdsCsv, int ancestorCount, int skip, int take, CancellationToken cancellationToken);
    }
}
