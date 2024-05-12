using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.OrderItems;

public interface IOrderItemRepository:IGenericRepository<OrderItem>
{
    void addOrderItemsList(IEnumerable<OrderItem> model);
}
