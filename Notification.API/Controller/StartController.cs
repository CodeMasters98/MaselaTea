using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controller
{
    public class StartController : BaseController
    {
        public IActionResult Version()
        {
            return Ok("Version v1.0.0");
        }
    }
}
