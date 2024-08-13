using Notification.API.Enums;
using Notification.API.Shared;

using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Notification.API.Models;

[Entity]
public class Notification
{
    public int Id { get; set; }

    public string Message { get; set; }

    public string Reciever { get; set; }

    public NotficationType NotficationType { get; set; }

    public int CreatedByUserId { get; set; }    
}
