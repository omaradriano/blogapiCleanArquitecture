namespace Application.Services.Authentication;

public record AuthenticationResult
(
    Guid Id,
    string Username,
    string Email,
    string Token
);