using Project.DAL.Repositories.CartProduct;
using Project.DAL.Repositories.Carts;
using Project.DAL.Repositories.Categories;
using Project.DAL.Repositories.OrderItems;
using Project.DAL.Repositories.Orders;
using Project.DAL.Repositories.Products;
using Project.DAL.Repositories.Users;

namespace Project.DAL.UnitOfWork;

public interface IUnitRepository
{
    public ICategoryRepository category { get; }
    public IProductRepository product { get; }
    public ICartProductRepository cartProduct { get; }
    public ICartRepository cart { get; }
    public IOrderRepository order { get; }
    public IOrderItemRepository orderItem { get; }
    public IUserRepository user { get; }
    void SaveChanges();
}
