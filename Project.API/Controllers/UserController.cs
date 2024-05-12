using Microsoft.AspNetCore.Mvc;
using Project.BL.Dtos.StatusCode;
using Project.BL.Dtos.Users;
using Project.BL.Services.UnitService;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUnitService _unit;
    public UserController(IUnitService unit)
    {
        _unit = unit;
    }

    [HttpPost]
    [Route("Signup")]
    public async Task<IActionResult> Signup(SignupDTO user)
    {
       StatusCodeDTO result = await _unit.auth.registration(user);
       return StatusCode((int)result.Statuscode, result.data?? result.message);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginDTO login)
    {
       StatusCodeDTO result = await _unit.auth.Login(login);
       return StatusCode((int)result.Statuscode, result.data ?? result.message);
    }
}