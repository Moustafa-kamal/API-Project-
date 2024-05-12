using Microsoft.EntityFrameworkCore;
using Project.DAL.Data;
using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.Carts;

public class CartRepository:GenericRepository<Cart>, ICartRepository
{
    public CartRepository(APIContext context):base(context){}

    public Cart? getCartByUserId(string userid)
    {
       return _context.carts.Where(c => c.UserId == userid)
            .Include(c => c.Product)
            .ThenInclude(p=>p.Product)
            .FirstOrDefault();
    }
}
