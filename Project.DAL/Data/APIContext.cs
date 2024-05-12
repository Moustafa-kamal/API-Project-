using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Models;

namespace Project.DAL.Data;

public class APIContext:IdentityDbContext<User>
{
    public APIContext(DbContextOptions option) : base(option) { }

    public DbSet<Cart> carts { get; set; }
    public DbSet<CartProducts> cartProducts { get; set; }
    public DbSet<Category> category { get; set; }
    public DbSet<Order> order { get; set; }
    public DbSet<OrderItem> orderItems { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<User> user { get; set; }
}
