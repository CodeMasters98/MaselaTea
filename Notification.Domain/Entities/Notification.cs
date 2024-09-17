
using Notification.Domain.Enums;
using Notification.Domain.ValueObjects;

namespace Notification.Domain.Entities;

//[Entity]
public class Notification
{
   public void Add(string message, string reciever, NotficationType notficationType, int createdByUserId, Price price) 
    { 
        //
    }

    public int Id { get; set; }
    public string Message { get; set; }
    public string Reciever { get; set; }
    public NotficationType NotficationType { get; set; }
    public int CreatedByUserId { get; set; }
    public Price Price { get; set; }


}
