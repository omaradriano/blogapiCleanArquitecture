namespace Infrastructure;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Infrastructure.Authentication;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services){
        // services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }   
}