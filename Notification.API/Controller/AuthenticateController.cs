using Microsoft.AspNetCore.Mvc;
using Notification.Application.Dtos;
using Notification.Application.Usecases.Authenticate;

namespace Notification.API.Controller;

public class AuthenticateController : BaseController
{
    public async Task<IActionResult> Login(LoginCommand command, CancellationToken ct)
        => await SendAsync(command, ct);

    public async Task<IActionResult> Register(RegisterCommand command, CancellationToken ct)
        => await SendAsync(command, ct);
}
