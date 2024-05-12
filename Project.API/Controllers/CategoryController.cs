using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.Dtos.Category;
using Project.BL.Dtos.StatusCode;
using Project.BL.Services.UnitService;
using Project.DAL.Models;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IUnitService _unit;

    public CategoryController(IUnitService unit)
    {
        _unit = unit;
    }

    [HttpGet]
    [Route("GetAll")]
   public IActionResult GetAll()
    {
        StatusCodeDTO result = _unit.categories.GetAllCategories();
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

    [HttpGet]
    [Route("GetCategory")]
    public IActionResult GetCategory(int id)
    {
        var category = _unit.categories.GetCategoryWithProduct(id);
        return StatusCode((int)category.Statuscode, category.data?? category.message);
    }

    [HttpPost]
    [Route("AddCategory")]
    public IActionResult AddCategory(CategoryInsertDTO category)
    {
       StatusCodeDTO result = _unit.categories.AddCategory(category);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }

    [HttpPut]
    [Route("UpdateCategory")]
    public IActionResult UpdateCategory(int id,CategoryInsertDTO category)
    {
        StatusCodeDTO result = _unit.categories.UpdateCategory(id,category);
        return StatusCode((int)result.Statuscode,result.data?? result.message);
    }

    [HttpDelete]
    [Route("DeleteCategory")]
    public IActionResult DeleteCategory(int id)
    {
        StatusCodeDTO result =_unit.categories.DeleteCategory(id);
        return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }
}