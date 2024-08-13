using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;
using Models = Notification.API.Models;

namespace Notification.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Notification");
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.NoAction;

            base.OnModelCreating(builder);
        }

        public new async Task SaveChangesAsync(CancellationToken ct = default)
        {
            OnBeforeSaving();
            await base.SaveChangesAsync(ct);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.CurrentValues["IsDeleted"] = false;
                        break;

                    case EntityState.Deleted:
                        //entry.State = EntityState.Modified;
                        //entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }

        public DbSet<Models.Notification> Notifications { get; set; }
        public DbSet<Models.Report> Reports { get; set; }


    }
}
