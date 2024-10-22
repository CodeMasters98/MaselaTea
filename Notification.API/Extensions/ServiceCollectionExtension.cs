using Microsoft.EntityFrameworkCore;

namespace Notification.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer()
                .AddSwaggerGen();
        return services;
    }
}
