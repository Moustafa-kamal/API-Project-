using Microsoft.AspNetCore.Identity;
using Project.BL.Dtos.Users;
using Project.DAL.Models;

namespace Project.BL.Mappers.Users;
public class UserMapper : IUserMapper
{
    public User? SignToUser(SignupDTO sign)
    {
        return new User()
        {
            FirstName = sign.FirstName,
            LastName = sign.LastName,
            Email = sign.Email,
            UserName = sign.Email
        };
    }
}
