using Project.BL.Dtos.OrderItem;

namespace Project.BL.Dtos.Orders;

public record OrderReadDTO
{
    public int Id { get; init; }
    public DateTime ShippingDate { get; init; } = DateTime.UtcNow;
    public DateTime DeliverDate { get; init; } = DateTime.UtcNow.AddDays(3);
    public string ShippingAddress { get; init; } = string.Empty;
    public string UserId { get; init; } = string.Empty;
    public IEnumerable<OrderItemReadDTO> Items { get; init; } = null!;
}
