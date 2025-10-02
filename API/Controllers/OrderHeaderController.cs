using System.Net;
using API.Data;
using API.DTOs;
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
            .FirstOrDefault(x => x.OrderHeaderId == orderId);

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
    
    [HttpPost]
    public ActionResult<ApiResponse> CreateOrder([FromBody] OrderHeaderCreateDTO orderHeaderDTO)
    {
        try
        {
            if (ModelState.IsValid)
            {
                OrderHeader orderHeader = new()
                {
                    PickUpName = orderHeaderDTO.PickUpName,
                    PickUpPhoneNumber = orderHeaderDTO.PickUpPhoneNumber,
                    PickUpEmail = orderHeaderDTO.PickUpEmail,
                    OrderDate = DateTime.Now,
                    OrderTotal = orderHeaderDTO.OrderTotal,
                    Status = StaticDetails.status_confirmed,
                    TotalItem = orderHeaderDTO.TotalItem,
                    ApplicationUserId = orderHeaderDTO.ApplicationUserId
                };

                _db.OrderHeaders.Add(orderHeader);
                _db.SaveChanges();

                foreach(var orderDetailDTO in orderHeaderDTO.OrderDetailsDTO)
                {
                    OrderDetail orderDetail = new()
                    {
                        OrderHeaderId = orderHeader.OrderHeaderId,
                        MenuItemId = orderDetailDTO.MenuItemId,
                        Quantity = orderDetailDTO.Quantity,
                        ItemName = orderDetailDTO.ItemName,
                        Price = orderDetailDTO.Price
                    };
                    _db.OrderDetails.Add(orderDetail);
                }
                _db.SaveChanges();
                _response.Result = orderHeader;
                orderHeader.OrderDetails = [];
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtAction(nameof(GetOrder), new { orderId = orderHeader.OrderHeaderId }, _response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();
                return BadRequest(_response);
            }
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.ErrorMessages.Add(ex.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError, _response);
        }
    }
}
