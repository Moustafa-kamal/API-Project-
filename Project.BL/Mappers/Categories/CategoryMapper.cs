using Project.BL.Dtos.Category;
using Project.BL.Dtos.Product;
using Project.BL.Mappers.Products;
using Project.DAL.Models;

namespace Project.BL.Mappers.Categories;

public class CategoryMapper : ICategoryMapper
{
    private readonly IProductMapper _productmapper;

    public CategoryMapper(IProductMapper productMapper)
    {
        _productmapper = productMapper;
    }
    public CategoryWithProductDTO CategoryWithProductDTO(Category category)
    {
        IEnumerable<ProductReadDTO> products = _productmapper.listModelToReadDTO(category.Products);
        return new CategoryWithProductDTO(category.Id,category.Name, products);
    }

    public Category insertToModel(CategoryInsertDTO insertDTO)
    {
        return new Category()
        {
            Name = insertDTO.Name
        };
    }

    public IEnumerable<CategoryReadDTO> listModelToReadDTO(IEnumerable<Category> category)
    {
        return category.Select(i => modelToRead(i));
    }

    public CategoryReadDTO modelToRead(Category model)
    {
        return new CategoryReadDTO(model.Id,model.Name);
    }
}
