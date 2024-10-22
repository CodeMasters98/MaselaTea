using Notification.Application.Contracts;
using Notification.Domain.Entities;

namespace Notification.Infrastructure.Presistance.Repositories;

public class ReportRepository : GenericRepository<Report>, IReportRepository
{
    public ReportRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
