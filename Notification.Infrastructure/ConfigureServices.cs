using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Contracts;
using Notification.Infrastructure.Caching;
using Notification.Infrastructure.Presistance;
using Notification.Infrastructure.Presistance.Repositories;

namespace Notification.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>((options) =>
        {
            //options.UseSqlServer(connectionString);
            options.UseInMemoryDatabase("DB");
        });

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "Notification_";
        });


        services.AddTransient<IReportRepository, ReportRepository>();
        services.AddTransient<INotificationRepository, NotificationRepository>();
        services.AddScoped<IRedisCacheService, RedisCacheService>();

        return services;
    }
}
