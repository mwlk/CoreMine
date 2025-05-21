namespace CoreMine.ApplicationBusiness.Interfaces.Shared
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
