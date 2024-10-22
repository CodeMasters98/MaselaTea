using Notification.Domain.Entities;

namespace Notification.Application.Contracts;

public interface IReportRepository
{
    List<Report> GetReport();
}
