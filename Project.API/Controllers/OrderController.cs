using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BL.Dtos.Orders;
using Project.BL.Dtos.StatusCode;
using Project.BL.Services.UnitService;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IUnitService _unit;

    public OrderController(IUnitService unit)
    {
        _unit = unit;
    }

    [Authorize]
    [Route("ViewOrderHistory")]
    [HttpGet]
    public async Task<IActionResult> ViewOrderHistory()
    {
       StatusCodeDTO result = await _unit.order.viewOrdersHistory(User);
       return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

    [Authorize]
    [Route("PlaceOrder")]
    [HttpPost]
    public async Task<IActionResult> PlaceOrder()
    {
        StatusCodeDTO result = await _unit.order.placeOrder(User);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);

    }
}
