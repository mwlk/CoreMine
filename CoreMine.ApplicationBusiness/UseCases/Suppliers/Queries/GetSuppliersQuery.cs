using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.Suppliers.Queries
{
    public class GetSuppliersQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public int[]? Ids { get; set; }
        public string? FullName { get; set; }

    }
}
