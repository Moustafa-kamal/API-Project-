using Project.BL.Services.AuthService;
using Project.BL.Services.CartProductService;
using Project.BL.Services.CartService;
using Project.BL.Services.CategoryService;
using Project.BL.Services.OrderItemService;
using Project.BL.Services.OrderService;
using Project.BL.Services.ProductService;

namespace Project.BL.Services.UnitService;

public interface IUnitService
{
    public ICartProductService cartproduct { get; }
    public ICartService cart {get;}
    public ICategoryService categories {get;}
    public IOrderService order {get;}
    public IProductService product {get;}
    public IOrderItemService orderitem {get;}
    public IAuthService auth {get;}
    public void saveChanges();

}
