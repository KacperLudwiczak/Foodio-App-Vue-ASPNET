using API.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthTestController : Controller
{
    [HttpGet]
    [Authorize]
    public ActionResult<string> GetValue()
    {
        return "You are authorized user";
    }

    [HttpGet("{value:int}")]
    [Authorize(Roles = StaticDetails.Role_Admin)]
    public ActionResult<string> GetValue(int value)
    {
        return "You are authorized user, with role of Admin";
    }
}
