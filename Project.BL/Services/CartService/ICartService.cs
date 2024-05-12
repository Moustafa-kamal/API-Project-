using Project.BL.Dtos.Cart;
using Project.BL.Dtos.CartProduct;
using Project.BL.Dtos.StatusCode;
using System.Security.Claims;

namespace Project.BL.Services.CartService;

public interface ICartService
{
    void createCart(string userId);
    Task<StatusCodeDTO> getCart(ClaimsPrincipal user);
    Task<StatusCodeDTO> addToCart(ClaimsPrincipal user,CartProductReadDTO insert);
    Task<StatusCodeDTO> deleteProductinCart(ClaimsPrincipal user, int productId);
    Task<StatusCodeDTO> clearCart(ClaimsPrincipal user);
}
