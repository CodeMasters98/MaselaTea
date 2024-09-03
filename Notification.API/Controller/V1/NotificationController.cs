using Microsoft.AspNetCore.Mvc;
using Notification.Application.Contracts;
using Notification.Application.Dtos;
using System.Net.Mime;

using Model = Notification.Domain.Entities;

namespace Notification.API.Controller.V1;

public class NotificationController : BaseController
{
    private readonly INotificationRepository _notificationRepository;
    public NotificationController(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    [HttpPost]
    [Route("Send")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public bool Send([FromBody] SendNotificationDto dto)
    {
        var notification = new Model.Notification()
        {
            Message = dto.Message,
            NotficationType = dto.NotficationType,
            Reciever = dto.Reciever,
        };
        _notificationRepository.Add(notification);
        return true;
    }
}
