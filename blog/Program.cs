
using Infrastructure;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    //Dependency injection for infrastructure 
    builder.Services.AddInfrastructure();
    //Dependency injection for application
    builder.Services.AddApplication();

    //jwt authentication
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //Receive JWt token in the header
        .AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, //solo acepta tokens emitidos por el servidor
                ValidateAudience = true, //Acepta tokens dirigidos al cliente
                ValidateLifetime = true, //Rechaza tokens expirados
                ValidateIssuerSigningKey = true, //Rechaza tokens con firma invalida
                ValidIssuer = "http://localhost:5103",
                ValidAudience = "http://localhost:5103",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iliketurtles01.")),
                
            };
        });
    builder.Services.AddAuthorization();
}

var app = builder.Build();
{
    app.UseAuthorization();
    app.UseAuthentication();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}