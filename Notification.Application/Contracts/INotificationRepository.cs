using Entities = Notification.Domain.Entities;

namespace Notification.Application.Contracts;

public interface INotificationRepository : IGenericRepository<Entities.Notification>
{
   
}
