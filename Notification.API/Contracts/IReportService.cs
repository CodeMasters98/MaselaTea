using Notification.API.Models;

namespace Notification.API.Contracts;

public interface IReportService
{
    List<Report> GetReport();
}
