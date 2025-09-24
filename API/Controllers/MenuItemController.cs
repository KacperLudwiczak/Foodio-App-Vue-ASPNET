using System.Net;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/MenuItem")]
[ApiController]
public class MenuItemController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly ApiResponse _response;

    public MenuItemController(ApplicationDbContext db)
    {
        _db = db;
        _response = new ApiResponse();
    } 

    [HttpGet]
    public IActionResult GetMenuItems()
    {
        List<MenuItem> menuItems = _db.MenuItems.ToList();

        _response.Result = menuItems;
        _response.StatusCode = HttpStatusCode.OK;
        return Ok(_response);
    }
}
