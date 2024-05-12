using Project.BL.Dtos.Cart;
using Project.BL.Dtos.CartProduct;
using Project.BL.Mappers.CartProductsm;
using Project.DAL.Models;

namespace Project.BL.Mappers.Carts;

public class CartMapper : ICartMapper
{
    private readonly ICartProductMapper _cartProductMapper;

    public CartMapper(ICartProductMapper cartProductMapper)
    {
        _cartProductMapper = cartProductMapper;
    }
    public CartReadDTO CartModelTORead(Cart cart)
    {
        IEnumerable<CartProductReadDTO> cartProductDTO = _cartProductMapper.listModelToReadDTO(cart.Product);
        return new CartReadDTO(cart.Id, cart.UserId, cartProductDTO, cart.Total);
    }
}
