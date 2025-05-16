using CoreMine.Models.DTOs;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Commands
{
    public class AddProductCommand 
    {
        public ProductPostDto ProductToAdd { get; set; }

        public AddProductCommand(ProductPostDto productToAdd)
        {
            ProductToAdd = productToAdd;
        }
    }
}
