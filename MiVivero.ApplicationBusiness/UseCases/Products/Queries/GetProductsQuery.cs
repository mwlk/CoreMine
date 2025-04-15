using MediatR;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Queries
{
    public class GetProductsQuery: IRequest<IEnumerable<ProductViewModel>>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        //public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
