using Microsoft.EntityFrameworkCore;
using Notification.API.Contracts;
using Notification.API.Data;
using Notification.API.Services;

namespace Notification.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<AppDbContext>((options) =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IReportService, ReportService>();
        services.AddTransient<INotificationService, NotificationService>();

        return services;
    }
}
