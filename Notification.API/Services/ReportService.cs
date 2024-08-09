using Notification.API.Contracts;
using Notification.API.Models;

namespace Notification.API.Services;

public class ReportService : IReportService
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
