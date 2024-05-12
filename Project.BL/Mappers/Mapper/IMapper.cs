using Project.BL.Mappers.CartProductsm;
using Project.BL.Mappers.Carts;
using Project.BL.Mappers.Categories;
using Project.BL.Mappers.Images;
using Project.BL.Mappers.OrderItems;
using Project.BL.Mappers.Orders;
using Project.BL.Mappers.Products;
using Project.BL.Mappers.Users;

namespace Project.BL.Mappers.Mapper;

public interface IMapper
{
    public ICartProductMapper cartProduct { get; }
    public ICartMapper cart { get; }
    public IImageMapper image { get; }
    public ICategoryMapper category { get; }
    public IOrderMapper order { get; }
    public IOrderItemMapper orderItem { get; }
    public IProductMapper product { get; }
    public IUserMapper user { get; }
}
