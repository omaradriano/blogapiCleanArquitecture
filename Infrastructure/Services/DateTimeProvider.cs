using Application.Common.Interfaces.Services;

namespace Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public int ExtraMinutes{get; set;}

        public string GetActualUnixTime()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
        }

        public string GetExpireUnixTime(){
            return new DateTimeOffset(DateTime.UtcNow.AddMinutes(this.ExtraMinutes)).ToUnixTimeSeconds().ToString();
        }
    }
}