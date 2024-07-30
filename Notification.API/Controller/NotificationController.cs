using Microsoft.AspNetCore.Mvc;
using Notification.API.Dtos;
using System.Net.Mime;

using Model = Notification.API.Models;

namespace Notification.API.Controller;

public class NotificationController : BaseController
{

    [HttpPost]
    [Route("Send")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public bool Send([FromBody] SendNotificationDto dto)
    {
        var notification = new Models.Notification()
        {
            Message = dto.Message,
            NotficationType = dto.NotficationType,
            Reciever =dto.Reciever,
        };
        return true;
    }
}
