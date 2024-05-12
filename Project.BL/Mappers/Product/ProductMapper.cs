using Project.BL.Dtos.Category;
using Project.BL.Dtos.Product;
using Project.BL.Mappers.Categories;
using Project.BL.Mappers.Images;
using Project.DAL.Models;

namespace Project.BL.Mappers.Products;

public class ProductMapper : IProductMapper
{
    private readonly IImageMapper _imagemapper;

    public ProductMapper(IImageMapper imageMapper)
    {
        _imagemapper = imageMapper;
    }
    public Product insertToModel(ProductInsertDTO insert)
    {
        return new Product()
        {
            Name = insert.Name,
            Price = insert.Price,
            Categoryid = insert.Categoryid,
            Quantity = insert.Quantity,
            Image = _imagemapper.ConvertImage(insert.Image),
        };
    }

    public IEnumerable<ProductReadDTO> listModelToReadDTO(IEnumerable<Product> model)
    {
        return model.Select(i => modelToReadDTO(i)) ;
    }

    public ProductReadDTO modelToReadDTO(Product model)
    {
        return new ProductReadDTO(model.Id,model.Name,model.Image,model.Quantity,model.Price,model.Categoryid);
    }

    public ProductWithCategoryDTO modelToReadWithCategory(Product model)
    {
        CategoryReadDTO categoryDTO = new CategoryReadDTO(model.Category.Id, model.Category.Name);
        return new ProductWithCategoryDTO(model.Id, model.Name, model.Image, model.Quantity, model.Price,categoryDTO);
    }
}
