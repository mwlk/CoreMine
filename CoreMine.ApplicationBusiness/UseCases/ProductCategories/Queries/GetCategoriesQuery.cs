using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.Categories.Queries
{
    public class GetCategoriesQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public bool? IsParent { get; set; } = false;

    }
}
