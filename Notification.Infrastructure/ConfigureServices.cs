using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Contracts;
using Notification.Infrastructure.Presistance;
using Notification.Infrastructure.Presistance.Repositories;

namespace Notification.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>((options) =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IReportRepository, ReportRepository>();
        services.AddTransient<INotificationRepository, NotificationRepository>();


        return services;
    }
}
