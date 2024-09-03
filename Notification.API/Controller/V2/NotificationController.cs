using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controller.V2
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
