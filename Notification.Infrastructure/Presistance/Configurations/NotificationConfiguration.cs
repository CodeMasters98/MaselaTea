using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entity = Notification.Domain.Entities;

namespace Notification.Infrastructure.Presistance.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Entity.Notification>
{
    public void Configure(EntityTypeBuilder<Entity.Notification> builder)
    {
        //builder.OwnsOne(n => n.Price);
        //proprt config
        //table config
        //relatio fixup
    }
}

