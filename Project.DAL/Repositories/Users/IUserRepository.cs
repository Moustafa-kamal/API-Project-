using Project.DAL.Models;
using System.Security.Claims;

namespace Project.DAL.Repositories.Users;
public interface IUserRepository
{
    Task<User>? GetUser(ClaimsPrincipal user);
}
