namespace Infrastructure;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Infrastructure.Authentication;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            // Microsoft.Extensions.Configuration.ConfigurationManager used to extract JwtSettings from appsettings.Development.json
            ConfigurationManager configuration 
        ) {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }   
}