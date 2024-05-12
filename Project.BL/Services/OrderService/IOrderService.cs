using Project.BL.Dtos.StatusCode;
using System.Security.Claims;

namespace Project.BL.Services.OrderService;
public interface IOrderService
{
    Task<StatusCodeDTO> viewOrdersHistory(ClaimsPrincipal user);
    Task<StatusCodeDTO> placeOrder(ClaimsPrincipal user);
}
