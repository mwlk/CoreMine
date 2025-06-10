namespace CoreMine.ApplicationBusiness.Exceptions
{
    public abstract class BusinessException : Exception
    {
        protected BusinessException(string message) : base(message) { }
    }

}
