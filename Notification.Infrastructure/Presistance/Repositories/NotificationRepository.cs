using Entites = Notification.Domain.Entities;

using Notification.Application.Contracts;
using Notification.Domain.Entities;

namespace Notification.Infrastructure.Presistance.Repositories;

public class NotificationRepository: INotificationRepository
{
    private readonly AppDbContext _appDbContext;
    public NotificationRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Entites.Notification> GetAll()
    {
        return _appDbContext.Set<Entites.Notification>().ToList();
    }

    public bool Add(Entites.Notification notification)
    {
        Console.WriteLine(_appDbContext.Entry(notification).State);
        _appDbContext.Set<Entites.Notification>().Add(notification);
        Console.WriteLine(_appDbContext.Entry(notification).State);
        _appDbContext.SaveChanges();
        Console.WriteLine(_appDbContext.Entry(notification).State);
        return true;
    }
}
