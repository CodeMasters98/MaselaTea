using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controller;

public class ReportController : BaseController
{

    [HttpGet]
    [Route("Get")]
    public IActionResult Get()
    {
        return null;
    }
}
