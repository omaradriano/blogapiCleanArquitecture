namespace Application.Common.Interfaces.Authentication;

public interface IJwtTokenHandler
{
    string GenerateToken(string email);
    void ValidateToken(string token);
}

