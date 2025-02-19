using ManagementSystem.DAL.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementSystem.DAL.SqlServer;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlServiceServices(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
        return services;
    }
}
