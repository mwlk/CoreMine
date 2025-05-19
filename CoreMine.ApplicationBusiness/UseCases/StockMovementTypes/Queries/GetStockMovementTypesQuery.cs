using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.StockMovementTypes.Queries
{
    public class GetStockMovementTypesQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public int[]? Ids { get; set; }
        public string? Name { get; set; }
        public bool? IsPositive { get; set; }
    }
}
