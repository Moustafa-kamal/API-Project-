using Microsoft.EntityFrameworkCore;
using Project.DAL.Data;
using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.Orders;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(APIContext context):base(context)
    {
        
    }

    public Order? GetOrder(int orderId)
    {
        return _context.order.Where(o => o.Id == orderId)
            .Include(o => o.Items)
            .FirstOrDefault();
    }

    public IEnumerable<Order> getOrdersHistory(string userId)
    {
        return _context.Set<Order>().Where(o => o.UserId == userId)
            .Include(o => o.Items)
            .ThenInclude(i => i.product)
            .ToList();
    }


}
