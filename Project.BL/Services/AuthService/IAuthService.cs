using Project.BL.Dtos.StatusCode;
using Project.BL.Dtos.Users;
using Project.DAL.Models;
using System.Security.Claims;

namespace Project.BL.Services.AuthService;
public interface IAuthService
{
    Task<StatusCodeDTO> registration(SignupDTO user);
    Task<StatusCodeDTO> Login(LoginDTO user);
}
