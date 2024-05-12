using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BL.Dtos.CartProduct;
using Project.BL.Dtos.StatusCode;
using Project.BL.Services.UnitService;
using Project.DAL.Models;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly IUnitService _unit;

    public CartController(IUnitService unit)
    {
        _unit = unit;
    }

    [Authorize]
    [HttpGet]
    [Route("GetCart")]
    public async Task<IActionResult> GetCart()
    {
        StatusCodeDTO result = await _unit.cart.getCart(User);
        return StatusCode((int)result.Statuscode,result.data?? result.message);
    }

    [Authorize]
    [HttpPost]
    [Route("AddToCart")]
    public async Task<IActionResult> AddToCart(CartProductReadDTO insert)
    {
        StatusCodeDTO result = await _unit.cart.addToCart(User, insert);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

    [Authorize]
    [HttpDelete]
    [Route("RemoveFromCart")]
    public async Task<IActionResult> RemoveFromCart(int productId)
    {
        StatusCodeDTO result = await _unit.cart.deleteProductinCart(User, productId);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

    [Authorize]
    [HttpDelete]
    [Route("ClearCart")]
    public async Task<IActionResult> ClearCart()
    {
        StatusCodeDTO result = await _unit.cart.clearCart(User);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }
}
