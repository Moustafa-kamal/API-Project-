using Project.BL.Dtos.Orders;
using Project.BL.Dtos.StatusCode;
using Project.BL.Mappers.Mapper;
using Project.DAL.Models;
using Project.DAL.UnitOfWork;
using System.Security.Claims;

namespace Project.BL.Services.OrderService;
public class OrderService : IOrderService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public OrderService(IUnitRepository unitRepository, IMapper mapper)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
    }
    public async Task<StatusCodeDTO> placeOrder(ClaimsPrincipal user)
    {
        User? existedUser =await _unitRepository.user.GetUser(user);
        if (existedUser == null)
            return new StatusCodeDTO(statuscode.NotFound,"Invalid Token");

        Cart? cart = _unitRepository.cart.getCartByUserId(existedUser.Id);
        if (cart == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no cart linked with you");
        if (cart.Product.Count() <= 0)
            return new StatusCodeDTO(statuscode.NotFound, "your cart is empty");


        Order order = new Order()
        {
            UserId = existedUser.Id
        };

        _unitRepository.order.Add(order);
        _unitRepository.SaveChanges();
        IEnumerable<OrderItem> orderItems = _mapper.orderItem.cartProductsToOrderItemlist(cart.Product,order.Id);

        _unitRepository.orderItem.addOrderItemsList(orderItems);
        _unitRepository.cartProduct.deleteAllbyCartId(cart.Id);

        Order? createdOrder = _unitRepository.order.GetOrder(order.Id);
        OrderReadDTO createdOrderDTO = _mapper.order.modelToRead(createdOrder);
        _unitRepository.SaveChanges();
        return new StatusCodeDTO(statuscode.Ok,null, createdOrderDTO);
    }

    public async Task<StatusCodeDTO> viewOrdersHistory(ClaimsPrincipal user)
    {
       User? existedUser = await _unitRepository.user.GetUser(user);
        if (existedUser == null)
            return new StatusCodeDTO(statuscode.NotFound,"Invalid Token");

       IEnumerable<Order> ordersModel = _unitRepository.order.getOrdersHistory(existedUser.Id);
       IEnumerable<OrderReadDTO> ordersDTO = _mapper.order.listModelToRead(ordersModel);

       return new StatusCodeDTO(statuscode.Ok,null, ordersDTO);
    }
}
