using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Wrappers;

namespace Notification.API.Controller;

[ApiController]
[Route("/api/v{v:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
    private ISender _mediator;
    private ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected async Task<ObjectResult> SendAsync<T>(IRequest<Response<T>> request, CancellationToken ct = default)
    {
        var result = await Mediator.Send(request, ct);

        if (result.Success)
            return Ok(result);

        return Ok(result);

    }

    protected async Task<Response<T>> SendDirectAsync<T>(IRequest<Response<T>> request, CancellationToken ct = default)
    {
        var result = await Mediator.Send(request, ct);
        return result;
    }

    protected async Task<ObjectResult> SendAsync(IRequest<Response<object>> request, CancellationToken ct = default)
        => await SendAsync<object>(request, ct);

    protected async Task<ObjectResult> SendAsync(IRequest<Response<Guid>> request, CancellationToken ct = default)
        => await SendAsync<Guid>(request, ct);

    protected async Task<ObjectResult> SendAsync(IRequest<Response<int>> request, CancellationToken ct = default)
        => await SendAsync<int>(request, ct);

    protected async Task<ObjectResult> SendAsync(IRequest<Response<long>> request, CancellationToken ct = default)
        => await SendAsync<long>(request, ct);
}
