using Project.BL.Services.AuthService;
using Project.BL.Services.CartProductService;
using Project.BL.Services.CartService;
using Project.BL.Services.CategoryService;
using Project.BL.Services.OrderItemService;
using Project.BL.Services.OrderService;
using Project.BL.Services.ProductService;
using Project.DAL.UnitOfWork;

namespace Project.BL.Services.UnitService;
public class UnitService : IUnitService
{
    public UnitService(ICartProductService cartProductService,
        ICartService cartService,
        ICategoryService categoryService,
        IOrderService orderService,
        IProductService productService,
        IOrderItemService orderItemService,
        IAuthService authService,
        IUnitRepository unitRepository)
    {
        cartproduct = cartProductService;
        cart = cartService;
        categories = categoryService;
        order = orderService;
        product = productService;
        orderitem = orderItemService;
        auth = authService;
        _unitrepository = unitRepository;
    }
    public ICartProductService cartproduct { get; set; } = null!;
    public ICartService cart { get; } = null!;
    public ICategoryService categories { get; } = null!;
    public IOrderService order { get; } = null!;
    public IProductService product { get; } = null!;
    public IOrderItemService orderitem { get; } = null!;
    public IAuthService auth { get; } = null!;

    private readonly IUnitRepository _unitrepository;

    public void saveChanges()
    {
        _unitrepository.SaveChanges();
    }
}
