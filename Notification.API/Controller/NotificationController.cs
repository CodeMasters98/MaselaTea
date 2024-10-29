using Microsoft.AspNetCore.Mvc;
using Notification.Application.Usecases.Notification;
using Model = Notification.Domain.Entities;
using System.Net.Mime;

namespace Notification.API.Controller;

public class NotificationController : BaseController
{
    //[Authorize]
    [HttpPost]
    [Route("Send")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Send([FromBody] AddNotificationCommand command, CancellationToken ct = default)
        => await SendAsync<bool>(command, ct);

    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateNotificationCommand command, CancellationToken ct = default)
        => await SendAsync<int>(command, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken ct = default)
        => await SendAsync(new GetAllNotificationQuery(), ct);
}
