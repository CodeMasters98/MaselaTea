using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controller.V1
{
    public class AuthenticateController : BaseController
    {
        public IActionResult Login()
        {
            return Ok();
        }

        public IActionResult Register()
        {
            return Ok();
        }
    }
}
