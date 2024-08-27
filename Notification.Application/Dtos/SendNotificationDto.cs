#nullable disable

using Notification.Domain.Enums;

namespace Notification.Application.Dtos;

public class SendNotificationDto
{
    public string Message { get; set; }
    public string Reciever { get; set; }
    public NotficationType NotficationType { get; set; }
}
