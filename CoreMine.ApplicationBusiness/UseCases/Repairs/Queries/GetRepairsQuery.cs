using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.Repairs.Queries
{
    public class GetRepairsQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public int[]? Ids { get; set; }
        public int? MachineId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? MachineIsActive { get; set; }
        public string? MachineCode { get; set; }
    }
}
