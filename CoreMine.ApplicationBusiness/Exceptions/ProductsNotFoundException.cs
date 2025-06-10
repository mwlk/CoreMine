namespace CoreMine.ApplicationBusiness.Exceptions
{
    public class ProductsNotFoundException : BusinessException
    {
        public ProductsNotFoundException(string message) : base($"Los productos: {message} no han sido encontrados en el sistema")
        {
        }
    }
}
