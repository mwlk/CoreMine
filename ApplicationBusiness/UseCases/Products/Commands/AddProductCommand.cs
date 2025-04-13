using MediatR;
using MiVivero.Models.DTOs;

namespace MiVivero.ApplicationBusiness.UseCases.Products.Commands
{
    public class AddProductCommand : IRequest<Unit>
    {
        public ProductPostDto ProductToAdd { get; set; }

        public AddProductCommand(ProductPostDto productToAdd)
        {
            ProductToAdd = productToAdd;
        }
    }
}
