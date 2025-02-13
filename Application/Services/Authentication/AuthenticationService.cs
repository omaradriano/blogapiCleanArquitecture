namespace Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService {

    public AuthenticationResult Login(string email, string password) {
        return new AuthenticationResult(Guid.NewGuid(), "username", email, "token xd");
    }

    public AuthenticationResult Register(string username, string email, string password) {
        return new AuthenticationResult(Guid.NewGuid(), username, email, "hardcoded-tokenn");
    }

}