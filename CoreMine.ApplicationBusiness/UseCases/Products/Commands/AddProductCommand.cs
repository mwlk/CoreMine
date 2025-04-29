using MediatR;
using CoreMine.Models.DTOs;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Commands
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
