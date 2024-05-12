using Project.BL.Dtos.Category;
using Project.BL.Dtos.StatusCode;
using Project.BL.Mappers.Mapper;
using Project.DAL.Models;
using Project.DAL.UnitOfWork;

namespace Project.BL.Services.CategoryService;

public class CategoryService:ICategoryService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public CategoryService(IUnitRepository unitRepository, IMapper mapper)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
    }

    public StatusCodeDTO AddCategory(CategoryInsertDTO category)
    {
        var Category = _unitRepository.category.GetCategorybyName(category.Name);

        if (Category != null)
        return new StatusCodeDTO(statuscode.NotFound,"This category is already exiest"); ;
        
        Category CreatedCategory = _mapper.category.insertToModel(category);
        _unitRepository.category.Add(CreatedCategory);
        _unitRepository.SaveChanges();
        return new StatusCodeDTO(statuscode.Created);
    }

    public StatusCodeDTO GetAllCategories()
    {
        IEnumerable<Category>? modelCategories = _unitRepository.category.GetAll();
        IEnumerable<CategoryReadDTO> readCategories = _mapper.category.listModelToReadDTO(modelCategories);
        return new StatusCodeDTO(statuscode.Ok,null, readCategories);
    }

    public StatusCodeDTO GetCategoryWithProduct(int id)
    {
        Category? category =  _unitRepository.category.GetCategoryWithProduct(id);
        if (category == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no category with this id");

        CategoryWithProductDTO ? categoryWithProduct = _mapper.category.CategoryWithProductDTO(category);
        return new StatusCodeDTO(statuscode.Ok, "There is no category with this id", categoryWithProduct);
    }

    public StatusCodeDTO UpdateCategory(int id,CategoryInsertDTO insert)
    {
        Category? Category = _unitRepository.category.Getone(id);
        if (Category == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no category with this id");
        
        Category? existedCategory = _unitRepository.category.GetCategorybyName(insert.Name);
        if (existedCategory != null)
            return new StatusCodeDTO(statuscode.NotFound, "There is already a category with this name");

        Category.Name = insert.Name;
        _unitRepository.category.Update(Category);
        _unitRepository.SaveChanges();
        return new StatusCodeDTO(statuscode.NoContent);
    }
    public StatusCodeDTO DeleteCategory(int id)
    {
        Category? Category = _unitRepository.category.Getone(id);

        if (Category == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no category with this id");
        
        _unitRepository.category.Delete(Category);
        _unitRepository.SaveChanges();
        return new StatusCodeDTO(statuscode.NoContent);
    }

}
