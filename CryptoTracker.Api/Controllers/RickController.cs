using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RickController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Index()
    {
        return "yo";
    }
}
