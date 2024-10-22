using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Notification.Infrastructure.Presistance.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<NotificationConfiguration>
{
    public void Configure(EntityTypeBuilder<NotificationConfiguration> builder)
    {
        //proprt config
        //table config
        //relatio fixup
    }
}

