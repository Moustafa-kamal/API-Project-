using Project.DAL.Data;
using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.OrderItems;

public class OrderItemRepository:GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(APIContext context):base(context) { }

    public void addOrderItemsList(IEnumerable<OrderItem> model)
    {
        _context.orderItems.AddRange(model);
    }
}
