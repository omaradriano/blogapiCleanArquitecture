namespace Domain;

public class JwtData
{
    public string Secret { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public int ExpireMinutes { get; init; }
}