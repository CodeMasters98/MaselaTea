

using Microsoft.Extensions.DependencyInjection;

namespace Notification.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddTransient<IReportService, ReportService>();
        //services.AddTransient<INotificationService, NotificationService>();

        return services;
    }
}
