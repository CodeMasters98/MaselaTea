using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace MaselaTea.Controllers;


[ApiController]
public class ProductController : Controller
{
    [HttpPost]
    [Route("Add")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPut]
    [Route("Update")]
    public IActionResult Update()
    {
        return View();
    }

    [HttpDelete]
    [Route("Delete")]
    public IActionResult Delete()
    {
        return View();
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {
        return View();
    }
}
