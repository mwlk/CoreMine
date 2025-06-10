using CoreMine.ApplicationBusiness.Common.Queries;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Queries
{
    public class GetProductsQuery : PaginatedQuery
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int[]? CategoryIds { get; set; }

        public string? Search { get; set; }           
        public string? Code { get; set; }             
        public string? CategoryName { get; set; }     
        public string? SupplierName { get; set; }     
        public string? LocationName { get; set; }     
        public string? State { get; set; }            
        public decimal? MinPrice { get; set; }        
        public decimal? MaxPrice { get; set; }        
        public decimal? MinStock { get; set; }        
        public decimal? MaxStock { get; set; }

        public string? SortBy { get; set; }
        public string? SortDirection { get; set; }
    }
}
