using Project.DAL.Data;
using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.CartProduct;

public class CartProductRepository:GenericRepository<CartProducts>,ICartProductRepository
{
    public CartProductRepository(APIContext context):base(context){}

    public void deleteAllbyCartId(int cartId)
    {
        IQueryable<CartProducts> cartItems = _context.cartProducts.Where(x => x.CartId == cartId);
        _context.cartProducts.RemoveRange(cartItems);
    }

    public void deleteOneByProductId(int id, int cartId)
    {
      CartProducts cartProducts = _context.cartProducts.First(cp => cp.ProductId == id);
        _context.cartProducts.Remove(cartProducts);
    }

    public CartProducts? getCartProductByProductId(int id,int cartId)
    {
        return _context.cartProducts.FirstOrDefault(cp => cp.ProductId == id && cp.CartId == cartId);
    }
}
