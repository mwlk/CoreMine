using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.Machines.Queries
{
    public class GetMachinesQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public int[]? Ids { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }
}
