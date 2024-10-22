using Entites = Notification.Domain.Entities;
using Notification.Application.Contracts;

namespace Notification.Infrastructure.Presistance.Repositories;

public class NotificationRepository:GenericRepository<Entites.Notification>, INotificationRepository
{
    public NotificationRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    //Code
}
