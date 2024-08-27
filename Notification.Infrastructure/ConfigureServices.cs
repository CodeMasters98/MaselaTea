using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notification.Infrastructure.Presistance;

namespace Notification.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>((options) =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }
}
