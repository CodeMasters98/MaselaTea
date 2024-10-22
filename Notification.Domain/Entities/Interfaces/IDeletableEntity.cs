namespace Notification.Domain.Entities.Interfaces;

public interface IDeletableEntity
{

    public DateTime DeletedAt { get; set; }
    public int DeletedByUserId { get; set; }
}
