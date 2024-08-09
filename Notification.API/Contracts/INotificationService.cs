namespace Notification.API.Contracts;

public interface INotificationService
{
    List<Notification.API.Models.Notification> GetAll();

    bool Add(Notification.API.Models.Notification notification);
}
