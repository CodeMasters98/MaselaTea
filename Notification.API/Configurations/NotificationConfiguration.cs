using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Notification.API.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<NotificationConfiguration>
{
    public void Configure(EntityTypeBuilder<NotificationConfiguration> builder)
    {
        //proprt config
        //table config
        //relatio fixup
    }
}
