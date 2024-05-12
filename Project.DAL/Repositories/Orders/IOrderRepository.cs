using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.Orders;

public interface IOrderRepository:IGenericRepository<Order>
{
    IEnumerable<Order> getOrdersHistory(string userId);
    Order? GetOrder(int orderId);
}
