using Project.BL.Dtos.Product;
using Project.DAL.Models;

namespace Project.BL.Mappers.Products;

public interface IProductMapper
{
    ProductReadDTO modelToReadDTO(Product model);
    Product insertToModel(ProductInsertDTO insert);
    ProductWithCategoryDTO modelToReadWithCategory(Product model);
    IEnumerable<ProductReadDTO> listModelToReadDTO(IEnumerable<Product> model);
}
