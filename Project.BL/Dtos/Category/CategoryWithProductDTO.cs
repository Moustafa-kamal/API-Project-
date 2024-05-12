using Project.BL.Dtos.Product;
namespace Project.BL.Dtos.Category;
public record CategoryWithProductDTO(int Id, string Name, IEnumerable<ProductReadDTO> Products);