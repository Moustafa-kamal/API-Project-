using Project.BL.Dtos.Category;
using Project.BL.Dtos.StatusCode;

namespace Project.BL.Services.CategoryService;
public interface ICategoryService
{
    StatusCodeDTO GetAllCategories();
    StatusCodeDTO GetCategoryWithProduct(int id);
    StatusCodeDTO AddCategory(CategoryInsertDTO category);
    StatusCodeDTO UpdateCategory(int id, CategoryInsertDTO insert);
    StatusCodeDTO DeleteCategory(int id);
}
 