using AspNetCoreRateLimit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ManagementSystem.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddMemoryCache();
        services.AddInMemoryRateLimiting();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        //services.Configure<IpRateLimitOptions>(Configuration.GetSection("ipRateLimiting");
        return services;
    }
}
