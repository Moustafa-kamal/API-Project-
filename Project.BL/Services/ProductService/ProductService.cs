using Project.BL.Dtos.Product;
using Project.BL.Dtos.StatusCode;
using Project.BL.Mappers.Mapper;
using Project.DAL.Models;
using Project.DAL.UnitOfWork;

namespace Project.BL.Services.ProductService;
public class ProductService : IProductService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public ProductService(IUnitRepository unitRepository,IMapper mapper)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
    }

    public StatusCodeDTO GetAllProducts()
    {
        IEnumerable<Product>? ProductsModels = _unitRepository.product.GetAll();
        IEnumerable<ProductReadDTO> productReadDTOs = _mapper.product.listModelToReadDTO(ProductsModels);
        return new StatusCodeDTO(statuscode.Ok, null, productReadDTOs);
    }

    public StatusCodeDTO GetProductsbyCategory(int id)
    {
        Category? category = _unitRepository.category.Getone(id);

        if (category == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no category with this id");
        
        IEnumerable<Product>? productReadDTOs = _unitRepository.product.GetProductbyCategory(id);
        IEnumerable<ProductReadDTO> productReads = _mapper.product.listModelToReadDTO(productReadDTOs);

        return new StatusCodeDTO(statuscode.Ok,null, productReads);
    }

    public StatusCodeDTO GetAProduct(int id)
    {
        Product? productModel = _unitRepository.product.GetProductWithCategory(id);
        if (productModel == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no product with this id");

        ProductWithCategoryDTO productWithCategory = _mapper.product.modelToReadWithCategory(productModel);
        return new StatusCodeDTO(statuscode.Ok,null, productWithCategory);
    }

    public StatusCodeDTO AddProduct(ProductInsertDTO insert)
    {
        Category? category = _unitRepository.category.Getone(insert.Categoryid);

        if (category == null)
            return new StatusCodeDTO(statuscode.NotFound,"There is no category with this id");
        
        Product productModel = _mapper.product.insertToModel(insert);
        _unitRepository.product.Add(productModel);
        _unitRepository.SaveChanges();

        return new StatusCodeDTO(statuscode.Created,null);
    }

    public StatusCodeDTO UpdateProduct(int id,ProductInsertDTO insert)
    {
        Product? product = _unitRepository.product.Getone(id);
        if (product == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no product with this id");
        
        Category? category = _unitRepository.category.Getone(insert.Categoryid);
        if (category == null)
            return new StatusCodeDTO(statuscode.NotFound, "There is no category with this id");

       /* Updating product properties */
        product.Name = insert.Name;
        product.Price = insert.Price;
        product.Categoryid = insert.Categoryid;
        if (insert.Image != null) product.Image = _mapper.image.ConvertImage(insert.Image);
        product.Quantity = insert.Quantity;

        _unitRepository.product.Update(product);
        _unitRepository.SaveChanges();
        return new StatusCodeDTO(statuscode.NoContent);
    }

    public StatusCodeDTO DeleteProduct(int id)
    {
        Product? product = _unitRepository.product.Getone(id);
        if (product == null)
            return new StatusCodeDTO(statuscode.NotFound,"There is no product with this id");
        
        _unitRepository.product.Delete(product);
        _unitRepository.SaveChanges();
        return new StatusCodeDTO(statuscode.NoContent);
    }

}
