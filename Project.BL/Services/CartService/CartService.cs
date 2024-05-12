using Project.BL.Dtos.Cart;
using Project.BL.Dtos.CartProduct;
using Project.BL.Dtos.StatusCode;
using Project.BL.Mappers.Mapper;
using Project.DAL.Models;
using Project.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Security.Claims;

namespace Project.BL.Services.CartService;
public class CartService : ICartService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public CartService(IUnitRepository unitRepository,IMapper mapper)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
    }

    public async Task<StatusCodeDTO> addToCart(ClaimsPrincipal user, CartProductReadDTO insert)
    {
        User? exiestUser = await _unitRepository.user.GetUser(user);
        if (exiestUser == null)
            return new StatusCodeDTO(statuscode.NotFound, "invalid Token");

        Cart? cart = _unitRepository.cart.getCartByUserId(exiestUser.Id);
        if (cart == null)
        {
            createCart(exiestUser.Id);
            return new StatusCodeDTO(statuscode.NotFound, "you don't have a cart but now you do try again");
        }

        Product? product = _unitRepository.product.Getone(insert.ProductId);
        if (product == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no product with this id");

        if (product.Quantity < insert.CartProductQuantity)
            return new StatusCodeDTO(statuscode.BadRequest, "There is no enough qunatity in the stock");

        if (insert.CartProductQuantity <= 0)
            return new StatusCodeDTO(statuscode.BadRequest, "quantity must be more than zero");

        CartProducts? cartProduct = _unitRepository.cartProduct.getCartProductByProductId(insert.ProductId,cart.Id);
        if (cartProduct == null)
        {
            CartProducts cartProducts = _mapper.cartProduct.readToModel(insert, cart.Id);
            _unitRepository.cartProduct.Add(cartProducts);
        }
        else
        {
            cartProduct.CartProductQuantity = insert.CartProductQuantity;
        }

        _unitRepository.SaveChanges();

        return new StatusCodeDTO(statuscode.Ok,null, insert);
    }

    public async Task<StatusCodeDTO> clearCart(ClaimsPrincipal user)
    {
        User? existedUser = await _unitRepository.user.GetUser(user);
        if (existedUser == null)
            return new StatusCodeDTO(statuscode.NotFound, "invalid Token");

        Cart? cart = _unitRepository.cart.getCartByUserId(existedUser.Id);
        if (cart == null)
            return new StatusCodeDTO(statuscode.NotFound,"There is no cart with this id");

        _unitRepository.cartProduct.deleteAllbyCartId(cart.Id);
        _unitRepository.SaveChanges();
        return new StatusCodeDTO(statuscode.NoContent);
    }

    public async void createCart(string userId)
    {
        Cart createdCart = new Cart()
        {
            UserId = userId,
        };
        _unitRepository.cart.Add(createdCart);
        _unitRepository.SaveChanges();
    }

    public async Task<StatusCodeDTO> deleteProductinCart(ClaimsPrincipal user, int productId)
    {
        User? existedUser = await _unitRepository.user.GetUser(user);
        if (existedUser == null)
            return new StatusCodeDTO(statuscode.NotFound, "Invalid Token");

        Cart? cart = _unitRepository.cart.getCartByUserId(existedUser.Id);
        if (cart == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no cart with this id");

        Product? product = _unitRepository.product.Getone(productId);
        if (product == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no product with this id");

        CartProducts? cartProduct = _unitRepository.cartProduct.getCartProductByProductId(productId, cart.Id);
        if (cartProduct == null)
            return new StatusCodeDTO(statuscode.NotFound, "This product is not in your cart");

        _unitRepository.cartProduct.deleteOneByProductId(productId,cart.Id);
        _unitRepository.SaveChanges();

        return new StatusCodeDTO(statuscode.NoContent);
    }

    public async Task<StatusCodeDTO> getCart(ClaimsPrincipal user)
    {
        User? existedUser = await _unitRepository.user.GetUser(user);
        if (existedUser == null)
            return new StatusCodeDTO(statuscode.NotFound, "invalid Token");

        Cart? cart = _unitRepository.cart.getCartByUserId(existedUser.Id);
        if (cart == null)
        {
            createCart(existedUser.Id);
            return new StatusCodeDTO(statuscode.NotFound, "you don't have a cart but now you do try again");
        }
        CartReadDTO cartDTO = _mapper.cart.CartModelTORead(cart);

        return new StatusCodeDTO(statuscode.Ok,null,cartDTO);
    }

}
