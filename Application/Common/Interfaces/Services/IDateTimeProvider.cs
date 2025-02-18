namespace Application.Common.Interfaces.Services
{
    public interface IDateTimeProvider
    {
        int ExtraMinutes { get; set;}

        string GetActualUnixTime();

        string GetExpireUnixTime(int minutes);
    }
}