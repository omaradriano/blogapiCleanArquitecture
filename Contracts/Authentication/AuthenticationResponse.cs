namespace blog.Contracts.Authentication;

public record AuthenticationResponse(
    string Username,
    string Email,
    string Token,
    Guid Id
);