using Microsoft.AspNetCore.Mvc;
using Notification.Application.Contracts;

namespace Notification.API.Controller;

public class ReportController : BaseController
{
    private readonly IReportRepository _reportRepository;
    public ReportController(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    [HttpGet]
    [Route("Get")]
    public IActionResult Get()
    {
        throw new NotImplementedException();
        //return Ok(_reportRepository.GetReport());
    }
}
