using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentication;

public class JwtTokenHandler(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions) : IJwtTokenHandler {

    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;

    public string GenerateToken(string email) {
        //Set expiration extra time
        _dateTimeProvider.ExtraMinutes = _jwtSettings.ExpireMinutes;
        //1. Generate claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //JSON ID preventing to be replayed
            new Claim(JwtRegisteredClaimNames.Exp, _dateTimeProvider.GetExpireUnixTime(), ClaimValueTypes.Integer64),
            new Claim(JwtRegisteredClaimNames.Iat, _dateTimeProvider.GetActualUnixTime(), ClaimValueTypes.Integer64),
        };

        //2. Create a symmetric key
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        //3. establish signin credentials and how the token will be encrypted
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //4. Create the token
        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            signingCredentials: creds);

        //5. Return the token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public void ValidateToken(string token){
        
    }

}