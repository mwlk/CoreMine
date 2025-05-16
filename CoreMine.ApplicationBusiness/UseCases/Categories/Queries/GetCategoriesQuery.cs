namespace CoreMine.ApplicationBusiness.UseCases.Categories.Queries
{
    public class GetCategoriesQuery 
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public bool? IsParent { get; set; } = false;
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
