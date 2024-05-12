using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.Products;

public interface IProductRepository:IGenericRepository<Product>
{
    IEnumerable<Product>? GetProductbyCategory(int id);
    Product? GetProductWithCategory(int id);

}
