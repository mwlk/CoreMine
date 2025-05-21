using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.Entities;

namespace CoreMine.ApplicationBusiness.UseCases.Products.Handlers
{
    public class AddProductHandler 
    {
        private readonly IRepository<Product> _productRepository;

        public AddProductHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
