using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.Stocks.Queries
{
    public class GetStocksQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public int[]? Ids { get; set; }
        public int[]? ProductIds { get; set; }
        public string? ProductName { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
    }
}
