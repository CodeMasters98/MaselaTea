using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using Notification.Application.Behaviors;

namespace Notification.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // MedeiatR

        var assembly = typeof(ConfigureServices).Assembly;
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
