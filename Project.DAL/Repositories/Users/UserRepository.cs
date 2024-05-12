using Microsoft.AspNetCore.Identity;
using Project.DAL.Models;
using System.Security.Claims;

namespace Project.DAL.Repositories.Users;
public class UserRepository:IUserRepository
{
    private readonly UserManager<User> _userManger;
    public UserRepository(UserManager<User> userManger)
    {
        _userManger = userManger;
    }
    public async Task<User>? GetUser(ClaimsPrincipal user)
    {
        return await _userManger.GetUserAsync(user);
    }
}
