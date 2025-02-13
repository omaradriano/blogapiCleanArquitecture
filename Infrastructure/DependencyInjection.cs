namespace Infrastructure;

using Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services){
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }   
}