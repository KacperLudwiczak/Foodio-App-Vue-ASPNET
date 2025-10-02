using System.Net;
using API.Data;
using API.Models;
using API.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class OrderHeaderController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly ApiResponse _response;
    public OrderHeaderController(ApplicationDbContext db)
    {
        _db = db;
        _response = new ApiResponse();
    }

    [HttpGet]
    public ActionResult<ApiResponse> GetOrders(string userId = "")
    {
        IEnumerable<OrderHeader> orderHeaderList = _db.OrderHeaders
            .Include(x => x.OrderDetails)
            .ThenInclude(x => x.MenuItem)
            .OrderByDescending(x => x.OrderHeaderId);

        if (!string.IsNullOrEmpty(userId))
        {
            orderHeaderList = orderHeaderList.Where(x => x.ApplicationUserId == userId);
            _response.Result = orderHeaderList;
        }
        else
        {
            if (User.IsInRole(StaticDetails.Role_Admin))
            {
                _response.Result = orderHeaderList;
            }
            else
            {
                _response.Result = new List<OrderHeader>();
            }
        }
        _response.StatusCode = HttpStatusCode.OK;
        return Ok(_response);
    }
    
    [HttpGet("{orderId:int}")]
    public ActionResult<ApiResponse> GetOrder(int orderId)
    {
        if (orderId == 0)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessages.Add("Invalid order Id");
            return BadRequest(_response);
        }

        OrderHeader? orderHeader = _db.OrderHeaders
            .Include(x => x.OrderDetails)
            .ThenInclude(x => x.MenuItem)
            .FirstOrDefault(x => x.OrderHeaderId==orderId);

        if (orderHeader == null)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.ErrorMessages.Add("Order not found");
            return NotFound(_response);
        }
        _response.Result = orderHeader;
        _response.StatusCode = HttpStatusCode.OK;
        return Ok(_response);
    }
}
