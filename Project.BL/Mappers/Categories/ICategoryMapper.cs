using Project.BL.Dtos.Category;
using Project.DAL.Models;

namespace Project.BL.Mappers.Categories;

public interface ICategoryMapper
{
    CategoryReadDTO modelToRead(Category model);
    Category insertToModel(CategoryInsertDTO insertDTO);
    CategoryWithProductDTO CategoryWithProductDTO(Category category);
    IEnumerable<CategoryReadDTO> listModelToReadDTO(IEnumerable<Category> category);
}
