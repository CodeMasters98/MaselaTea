
using Notification.Domain.Enums;

namespace Notification.Domain.Entities;

//[Entity]
public class Notification
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string Reciever { get; set; }
    public NotficationType NotficationType { get; set; }
    public int CreatedByUserId { get; set; }
}
