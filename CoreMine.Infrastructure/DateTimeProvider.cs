using CoreMine.ApplicationBusiness.Interfaces.Shared;

namespace CoreMine.Infraestructure
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
