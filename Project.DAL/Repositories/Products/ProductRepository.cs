using Microsoft.EntityFrameworkCore;
using Project.DAL.Data;
using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(APIContext context):base(context)
    {
    }

    public IEnumerable<Product>? GetProductbyCategory(int id)
    {
      return _context.Set<Product>().Where(p => p.Categoryid == id).ToList();
    }

    public Product? GetProductWithCategory(int id)
    {
        return _context.products.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();
    }
}
