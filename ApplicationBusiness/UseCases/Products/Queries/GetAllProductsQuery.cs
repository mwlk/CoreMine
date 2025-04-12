using MediatR;
using MiVivero.ApplicationBusiness.ViewModels;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Queries
{
    public class GetAllProductsQuery: IRequest<IEnumerable<ProductViewModel>>
    {
    }
}
