using Entities = Notification.Domain.Entities;

namespace Notification.Application.Contracts;

public interface INotificationRepository
{
    List<Entities.Notification> GetAll();

    bool Add(Entities.Notification notification);
}
