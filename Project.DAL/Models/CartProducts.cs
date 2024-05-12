using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Models;

[PrimaryKey(nameof(CartId), nameof(ProductId))]
public class CartProducts
{
    [ForeignKey("product")]
    public int ProductId { get; set; }
    [ForeignKey("cart")]
    public int CartId { get; set; }
    public int CartProductQuantity { get; set; }
    public Product Product { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
}
