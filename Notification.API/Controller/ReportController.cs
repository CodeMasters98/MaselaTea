using Microsoft.AspNetCore.Mvc;
using Notification.API.Contracts;
using Notification.API.Models;
using Notification.API.Services;

namespace Notification.API.Controller;

public class ReportController : BaseController
{
    //Dependancy Injection Pattern

    private readonly IReportService _reportService;
    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet]
    [Route("Get")]
    public IActionResult Get()
    {
        //Database
        //Log
        //Extrenal Service
        //Step1
        //ReportService service = new ReportService();


        return Ok(_reportService.GetReport());
    }
}
