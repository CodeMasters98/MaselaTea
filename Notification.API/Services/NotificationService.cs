using Notification.API.Contracts;

namespace Notification.API.Services;

public class NotificationService : INotificationService
{

    public static List<Notification.API.Models.Notification> notifications = null;

    public List<Notification.API.Models.Notification> GetAll()
    {
        return notifications;
    }

    public bool Add(Notification.API.Models.Notification notification)
    {
        if (notifications is null)
            notifications = new List<Models.Notification>();

        notifications.Add(notification);
        return true;
    }
}
