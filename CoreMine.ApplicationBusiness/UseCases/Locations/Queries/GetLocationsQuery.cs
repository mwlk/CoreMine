using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.Locations.Queries
{
    public class GetLocationsQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public int[]? Ids { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
