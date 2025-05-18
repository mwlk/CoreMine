namespace CoreMine.ApplicationBusiness.UseCases.ProductStateTypes.Queries
{
    public class GetProductStateTypeQuery
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
