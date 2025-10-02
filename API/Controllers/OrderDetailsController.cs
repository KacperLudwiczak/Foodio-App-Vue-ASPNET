using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class OrderDetailsController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly ApiResponse _response;
    public OrderDetailsController(ApplicationDbContext db)
    {
        _db = db;
        _response = new ApiResponse();
    }
}
