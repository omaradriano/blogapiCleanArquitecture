
using Infrastructure;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    var configValues = builder.Configuration.GetSection("JwtSettings");

    //Dependency injection for infrastructure 
    builder.Services.AddInfrastructure(builder.Configuration);
    //Dependency injection for application
    builder.Services.AddApplication();

    if(configValues["Secret"] == null){
        throw new Exception("Secret is null");
    }

    // System.Console.WriteLine(configValues["Secret"]);
    //jwt authentication
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //Receive JWt token in the header
        .AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, //solo acepta tokens emitidos por el servidor
                ValidateAudience = true, //Acepta tokens dirigidos al cliente
                ValidateLifetime = true, //Rechaza tokens expirados
                ValidateIssuerSigningKey = true, //Rechaza tokens con firma invalida
                ClockSkew = TimeSpan.Zero, //Asegura que el token no es valido antes de su fecha de emision (tiempo exacto)
                ValidIssuer = configValues["Issuer"],
                ValidAudience = configValues["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configValues["Secret"] ?? string.Empty)),    
            };
        });
    builder.Services.AddAuthorization();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}