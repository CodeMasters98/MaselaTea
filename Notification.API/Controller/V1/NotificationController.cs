using Microsoft.AspNetCore.Mvc;
using Notification.Application.Usecases.Notification;
using System.Net.Mime;

namespace Notification.API.Controller.V1;

public class NotificationController : BaseController
{
    //[Authorize]
    [HttpPost]
    [Route("Send")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Send([FromBody] AddNotificationCommand command, CancellationToken ct = default)
        => await SendAsync<int>(command, ct);
}
