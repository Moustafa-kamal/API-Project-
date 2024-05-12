using Microsoft.EntityFrameworkCore;
using Project.DAL.Data;
using Project.DAL.Models;
using Project.DAL.Repositories.Generic;

namespace Project.DAL.Repositories.Categories;

public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
{
    private readonly APIContext _context;
    public CategoryRepository(APIContext context):base(context){
        _context = context;
    }

    public Category? GetCategorybyName(string name)
    {
        return _context.Set<Category>().FirstOrDefault(c => c.Name == name);
    }

    public Category? GetCategoryWithProduct(int id)
    {
     var category =  _context.Set<Category>()
            .Where(c => c.Id == id)
            .Include(c => c.Products)
            .FirstOrDefault();
        return category;
    }
}
