#nullable disable

using Notification.API.Enums;

namespace Notification.API.Dtos;

public class SendNotificationDto
{
    public string Message { get; set; }
    public string Reciever { get; set; }
    public NotficationType NotficationType { get; set; }
}
