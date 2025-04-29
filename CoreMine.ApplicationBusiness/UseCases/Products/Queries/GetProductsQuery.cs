using MediatR;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Queries
{
    public class GetProductsQuery: IRequest<PagedResult<ProductViewModel>>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<int>? CategoryIds { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
