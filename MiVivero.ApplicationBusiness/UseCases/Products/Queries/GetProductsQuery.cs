using MediatR;
using MiVivero.Models.Common;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Queries
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
