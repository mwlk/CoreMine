using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.ProductStateTypes.Queries
{
    public class GetProductStateTypeQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
