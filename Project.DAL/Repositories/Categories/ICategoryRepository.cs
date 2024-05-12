using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.Categories;

public interface ICategoryRepository:IGenericRepository<Category>
{
    Category? GetCategoryWithProduct(int id);
    Category? GetCategorybyName(string name);

}
