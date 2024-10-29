
using MediatR;
using Microsoft.Extensions.Logging;

namespace Notification.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var start = DateTime.UtcNow;
        var result = await next();
        var end = DateTime.UtcNow;
        _logger.LogInformation($"{typeof(TRequest).Name} took: {(end - start).Milliseconds} Milliseconds");
        //if (!result.Success)
        //    _logger.LogError($"{result.Errors} ");
        return result;
    }
}