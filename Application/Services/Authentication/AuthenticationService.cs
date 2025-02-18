using Application.Common.Interfaces.Authentication;

namespace Application.Services.Authentication;

public class AuthenticationService(IJwtTokenHandler jwtTokenGenerator) : IAuthenticationService {

    private readonly IJwtTokenHandler _jwtTokenGenerator = jwtTokenGenerator;

    public AuthenticationResult Login(string email, string password) {
        return new AuthenticationResult(Guid.NewGuid(), "username", email, "token xd");
    }

    public AuthenticationResult Register(string username, string email, string password) {

        //Verificar que el usuario exista

        //Crear un usuario

        //Create token jwt
        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(email);

        return new AuthenticationResult(Guid.NewGuid(), username, email, token);
    }

}