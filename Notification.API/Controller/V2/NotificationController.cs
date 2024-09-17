using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controller.V2
{
    public class NotificationController : BaseController
    {
        public IActionResult Index()
        {
            return Ok();    
        }
    }
}
