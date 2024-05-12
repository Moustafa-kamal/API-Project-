using Project.BL.Dtos.CartProduct;
using Project.BL.Mappers.Carts;
using Project.DAL.Models;

namespace Project.BL.Mappers.CartProductsm;

public class CartProductMapper : ICartProductMapper
{
    public IEnumerable<CartProductReadDTO> listModelToReadDTO(IEnumerable<CartProducts> modelList)
    {
        return modelList.Select(i => modelToReadDTO(i));
    }

    public CartProductReadDTO modelToReadDTO(CartProducts model)
    {
        return new CartProductReadDTO(model.ProductId,model.CartProductQuantity);
    }

    public CartProducts readToModel(CartProductReadDTO read,int cartId)
    {
        return new CartProducts()
        {
            CartId = cartId,
            ProductId = read.ProductId,
            CartProductQuantity = read.CartProductQuantity
        };
    }
}
