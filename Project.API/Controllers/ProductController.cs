using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.BL.Dtos.Product;
using Project.BL.Dtos.StatusCode;
using Project.BL.Services.UnitService;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IUnitService _unit;

    public ProductController(IUnitService unit)
    {
        _unit = unit;
    }

    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        StatusCodeDTO result = _unit.product.GetAllProducts();
        return StatusCode((int)result.Statuscode,result.data?? result.message);
    }

    [HttpGet]
    [Route("GetProductsbyCategory")]
    public IActionResult GetProductsbyCategory(int id)
    {
        StatusCodeDTO result = _unit.product.GetProductsbyCategory(id);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);

    }

    [HttpGet]
    [Route("GetProduct")]
    public IActionResult GetProduct(int id)
    {
        StatusCodeDTO result = _unit.product.GetAProduct(id);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

    [HttpPost]
    [Route("AddProduct")]
    public IActionResult AddProduct([FromForm] ProductInsertDTO insert)
    {
        StatusCodeDTO result = _unit.product.AddProduct(insert);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

    [HttpPut]
    [Route("UpdateProduct")]
    public IActionResult UpdateProduct(int id,[FromForm] ProductInsertDTO insert)
    {
        StatusCodeDTO result = _unit.product.UpdateProduct(id,insert);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

    [HttpDelete]
    [Route("DeleteProduct")]
    public IActionResult DeleteProduct(int id)
    {
        StatusCodeDTO result = _unit.product.DeleteProduct(id);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

}
