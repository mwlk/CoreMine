namespace CoreMine.ApplicationBusiness.Exceptions
{
    public class InsufficientStockException : BusinessException
    {
        public InsufficientStockException(string product) : base($"El producto ${product} no posee stock")
        {

        }
    }
}
