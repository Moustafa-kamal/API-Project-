using Project.DAL.Data;
using Project.DAL.Repositories.CartProduct;
using Project.DAL.Repositories.Carts;
using Project.DAL.Repositories.Categories;
using Project.DAL.Repositories.OrderItems;
using Project.DAL.Repositories.Orders;
using Project.DAL.Repositories.Products;
using Project.DAL.Repositories.Users;

namespace Project.DAL.UnitOfWork;

public class UnitRepository : IUnitRepository
{
    public UnitRepository(ICategoryRepository categoryRepository,
        IProductRepository productRepository,
        ICartProductRepository cartProductRepository,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        ICartRepository cartRepository,
        IUserRepository userRepository,
        APIContext context)
    {
        category = categoryRepository;
        product = productRepository;
        cartProduct = cartProductRepository;
        order = orderRepository;
        cart = cartRepository;
        user = userRepository;
        orderItem = orderItemRepository;
        _context = context;
    }
    public ICategoryRepository category { get; } = null!;
    public IProductRepository product { get; } = null!;
    public ICartProductRepository cartProduct { get; } = null!;
    public ICartRepository cart { get; } = null!;
    public IOrderRepository order { get; } = null!;
    public IOrderItemRepository orderItem { get; } = null!;
    public IUserRepository user { get; } = null!;

    private readonly APIContext _context;

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
