
namespace Notification.Domain.Entities.Interfaces;

public interface IUpdateableEntity
{

    public DateTime UpdateAt { get; set; }
    public int UpdatedByUserId { get; set; }

}
