using Application.Common.Interfaces.Services;

namespace Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public int ExtraMinutes{get; set;} = 60;

        public string GetActualUnixTime()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
        }

        public string GetExpireUnixTime(int minutes){
            return new DateTimeOffset(DateTime.UtcNow.AddMinutes(this.ExtraMinutes)).ToUnixTimeSeconds().ToString();
        }
    }
}