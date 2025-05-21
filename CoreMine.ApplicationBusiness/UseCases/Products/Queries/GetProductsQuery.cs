namespace CoreMine.ApplicationBusiness.UseCases.Products.Queries
{
    public class GetProductsQuery
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int[]? CategoryIds { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
