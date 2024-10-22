using Microsoft.AspNetCore.Mvc;
using Notification.Application.Usecases.Authenticate;

namespace Notification.API.Controller.V1;

public class AuthenticateController : BaseController
{
    public async Task<IActionResult> Login(LoginCommand command,CancellationToken ct)
        => await SendAsync<bool>(command, ct);

    public async Task<IActionResult> Register(RegisterCommand command,CancellationToken ct)
        => await SendAsync<bool>(command, ct);
}
