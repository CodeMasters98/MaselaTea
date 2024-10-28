using FluentValidation;
using MediatR;
using Notification.Application.Wrappers;

namespace Notification.Application.Behaviors;
public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response<TResponse>
{

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult is null) 
            return await next();

        if (validationResult.IsValid) 
            return await next();


        var errors = validationResult.Errors;
        throw new ValidationException(errors);
    }
}
