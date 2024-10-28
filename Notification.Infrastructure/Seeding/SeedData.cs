using Microsoft.EntityFrameworkCore;
using Notification.Infrastructure.Presistance;
using Entity = Notification.Domain.Entities;


namespace Notification.Infrastructure.Seeding;
public static class SeedData
{
    public static void Seed(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Notifications.Any())
        {
            for (int i = 0; i < 10_000; i++)
            {
                context.Add(new Entity.Notification
                {
                    Message = $"Message {i}",
                    Reciever = $"Reciever {i}",
                });
            }

            context.SaveChanges();
        }
    }
}
