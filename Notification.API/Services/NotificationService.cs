using Notification.API.Contracts;
using Notification.API.Data;
using Models =  Notification.API.Models;

namespace Notification.API.Services;

public class NotificationService : INotificationService
{
    private readonly AppDbContext _appDbContext;
    public NotificationService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Notification.API.Models.Notification> GetAll()
    {
        return _appDbContext.Set<Models.Notification>().ToList();
    }

    public bool Add(Notification.API.Models.Notification notification)
    {
        Console.WriteLine(_appDbContext.Entry(notification).State);
        _appDbContext.Set<Models.Notification>().Add(notification);
        Console.WriteLine(_appDbContext.Entry(notification).State);
        _appDbContext.SaveChanges();
        Console.WriteLine(_appDbContext.Entry(notification).State);
        return true;
    }
}
