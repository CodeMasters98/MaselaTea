using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controller;

[ApiController]
[Route("/api/v{v:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
    
}
