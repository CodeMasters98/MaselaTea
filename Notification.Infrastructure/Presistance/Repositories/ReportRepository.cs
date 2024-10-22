using Notification.Application.Contracts;
using Notification.Domain.Entities;

namespace Notification.Infrastructure.Presistance.Repositories;

public class ReportRepository: IReportRepository
{
    public List<Report> GetReport()
    {
        List<Report> reports = new List<Report>()
        {
            new Report()
            {
                Count = 2,
                Name = "test",
                Price  = 140
            }
        };
        return reports;
    }
}
