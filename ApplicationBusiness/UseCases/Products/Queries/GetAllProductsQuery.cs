using MediatR;
using MiVivero.Models.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Queries
{
    public class GetAllProductsQuery: IRequest<IEnumerable<ProductViewModel>>
    {
    }
}
