using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public DateTime ShippingDate { get; set; } = DateTime.UtcNow;
    public DateTime DeliverDate { get; set; } = DateTime.UtcNow.AddDays(3);
    public string ShippingAddress { get; set; } = string.Empty;

    [ForeignKey("user")]
    public string UserId { get; set; } = string.Empty;
    public User user { get; set; } = null!;
    public IEnumerable<OrderItem> Items { get; set; } = null!;
}
