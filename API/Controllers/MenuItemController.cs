using System.Net;
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/MenuItem")]
[ApiController]
public class MenuItemController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly ApiResponse _response;
    private readonly IWebHostEnvironment _environment;

    public MenuItemController(ApplicationDbContext db, IWebHostEnvironment environment)
    {
        _db = db;
        _response = new ApiResponse();
        _environment = environment;
    }

    [HttpGet]
    public IActionResult GetMenuItems()
    {
        List<MenuItem> menuItems = _db.MenuItems.ToList();

        _response.Result = menuItems;
        _response.StatusCode = HttpStatusCode.OK;
        return Ok(_response);
    }

    [HttpGet("{id:int}", Name = "GetMenuItem")]
    public IActionResult GetMenuItem(int id)
    {
        if (id == 0)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            return BadRequest(_response);
        }

        MenuItem? menuItem = _db.MenuItems.FirstOrDefault(u => u.Id == id);

        _response.Result = menuItem;
        _response.StatusCode = HttpStatusCode.OK;
        return Ok(_response);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse>> CreateMenuItem([FromForm] MenuItemCreateDTO menuItemCreateDTO)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (menuItemCreateDTO.File == null || menuItemCreateDTO.File.Length == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ["File is required"];
                    return BadRequest(_response);
                }

                var imagesPath = Path.Combine(_environment.WebRootPath, "images");
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }

                var filePath = Path.Combine(imagesPath, menuItemCreateDTO.File.FileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                // Upload image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await menuItemCreateDTO.File.CopyToAsync(stream);
                }

                MenuItem menuItem = new()
                {
                    Name = menuItemCreateDTO.Name,
                    Description = menuItemCreateDTO.Description,
                    Price = menuItemCreateDTO.Price,
                    Category = menuItemCreateDTO.Category,
                    SpecialTag = menuItemCreateDTO.SpecialTag,
                    Image = "images/" + menuItemCreateDTO.File.FileName
                };

                _db.MenuItems.Add(menuItem);
                await _db.SaveChangesAsync();

                _response.Result = menuItemCreateDTO;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetMenuItem", new { id = menuItem.Id }, _response);
            }
            else
            {
                _response.IsSuccess = false;
            }
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = [ex.ToString()];
        }

        return BadRequest(_response);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse>> UpdateMenuItem(int id, [FromForm] MenuItemUpdateDTO menuItemUpdateDTO)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (menuItemUpdateDTO == null || menuItemUpdateDTO.Id != id)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                MenuItem? menuItemFromDb = await _db.MenuItems.FirstOrDefaultAsync(u => u.Id == id);

                if (menuItemFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                menuItemFromDb.Name = menuItemUpdateDTO.Name;
                menuItemFromDb.Description = menuItemUpdateDTO.Description;
                menuItemFromDb.Price = menuItemUpdateDTO.Price;
                menuItemFromDb.Category = menuItemUpdateDTO.Category;
                menuItemFromDb.SpecialTag = menuItemUpdateDTO.SpecialTag;

                if (menuItemUpdateDTO.File != null && menuItemUpdateDTO.File.Length > 0)
                {
                    var imagesPath = Path.Combine(_environment.WebRootPath, "images");
                    if (!Directory.Exists(imagesPath))
                    {
                        Directory.CreateDirectory(imagesPath);
                    }

                    var filePath = Path.Combine(imagesPath, menuItemUpdateDTO.File.FileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    var filePath_OldFile = Path.Combine(_environment.WebRootPath, menuItemFromDb.Image);
                    if (System.IO.File.Exists(filePath_OldFile))
                    {
                        System.IO.File.Delete(filePath_OldFile);
                    }

                    // Upload image
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await menuItemUpdateDTO.File.CopyToAsync(stream);
                    }

                    menuItemFromDb.Image = "images/" + menuItemUpdateDTO.File.FileName;
                }
                _db.MenuItems.Update(menuItemFromDb);
                await _db.SaveChangesAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
            }
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = [ex.ToString()];
        }

        return BadRequest(_response);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse>> DeleteMenuItem(int id)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                MenuItem? menuItemFromDb = await _db.MenuItems.FirstOrDefaultAsync(u => u.Id == id);

                if (menuItemFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                var filePath_OldFile = Path.Combine(_environment.WebRootPath, menuItemFromDb.Image);
                if (System.IO.File.Exists(filePath_OldFile))
                {
                    System.IO.File.Delete(filePath_OldFile);
                }

                _db.MenuItems.Remove(menuItemFromDb);
                await _db.SaveChangesAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
            }
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = [ex.ToString()];
        }

        return BadRequest(_response);
    }
}
