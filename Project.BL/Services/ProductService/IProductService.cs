using Project.BL.Dtos.Product;
using Project.BL.Dtos.StatusCode;

namespace Project.BL.Services.ProductService;
public interface IProductService
{
    StatusCodeDTO GetAllProducts();
    StatusCodeDTO GetProductsbyCategory(int id);
    StatusCodeDTO GetAProduct(int id);
    StatusCodeDTO AddProduct(ProductInsertDTO insert);
    StatusCodeDTO UpdateProduct(int id,ProductInsertDTO insert);
    StatusCodeDTO DeleteProduct(int id);
}
