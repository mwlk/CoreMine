using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.UnitOfMeasures.Queries
{
    public class GetUnitOfMeasuresQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public int[]? Ids { get; set; }
    }
}
