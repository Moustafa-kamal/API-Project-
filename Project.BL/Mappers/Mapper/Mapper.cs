using Project.BL.Mappers.CartProductsm;
using Project.BL.Mappers.Carts;
using Project.BL.Mappers.Categories;
using Project.BL.Mappers.Images;
using Project.BL.Mappers.OrderItems;
using Project.BL.Mappers.Orders;
using Project.BL.Mappers.Products;
using Project.BL.Mappers.Users;
namespace Project.BL.Mappers.Mapper;

public class Mapper : IMapper
{
    public Mapper(ICartProductMapper cartProductMapper,
        ICartMapper cartMapper,
        IImageMapper imageMapper,
        ICategoryMapper categoryMapper,
        IOrderMapper orderMapper,
        IOrderItemMapper orderItemMapper,
        IProductMapper productMapper,
        IUserMapper userMapper)
    {
        cartProduct = cartProductMapper;
        cart = cartMapper;
        image = imageMapper;
        category = categoryMapper;
        order = orderMapper;
        orderItem = orderItemMapper;
        product = productMapper;
        user = userMapper;

    }
    public ICartProductMapper cartProduct { get; } = null!;
    public ICartMapper cart { get; } = null!;
    public IImageMapper image { get; } = null!;
    public ICategoryMapper category { get; } = null!;
    public IOrderMapper order { get; } = null!;
    public IOrderItemMapper orderItem { get; } = null!;
    public IProductMapper product { get; } = null!;
    public IUserMapper user { get; } = null!;
}