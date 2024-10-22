using Notification.Domain.Entities.Interfaces;
using Notification.Domain.Enums;
using Notification.Domain.ValueObjects;

namespace Notification.Domain.Entities;

public class Notification : BaseEntity<long>
{
   public void Add(string message, string reciever, NotficationType notficationType, int createdByUserId, Price price) 
    { 
        //
    }

    public string Message { get; set; }
    public string Reciever { get; set; }
    public NotficationType NotficationType { get; set; }
    public int CreatedByUserId { get; set; }
    public Price Price { get; set; }
}
