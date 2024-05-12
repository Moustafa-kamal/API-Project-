using Microsoft.AspNetCore.Identity;

namespace Project.DAL.Models;

public class User:IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public IEnumerable<Order> Orders { get; set; } = null!;
    public Cart? Cart { get; set; } = null!;
}
