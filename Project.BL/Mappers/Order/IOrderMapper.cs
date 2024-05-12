using Project.BL.Dtos.Orders;
using Project.DAL.Models;

namespace Project.BL.Mappers.Orders;

public interface IOrderMapper
{
    OrderReadDTO modelToRead(Order model);
    IEnumerable<OrderReadDTO> listModelToRead(IEnumerable<Order> model);
}
