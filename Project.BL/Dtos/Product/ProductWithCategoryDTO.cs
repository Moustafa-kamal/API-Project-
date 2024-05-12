using Project.BL.Dtos.Category;
namespace Project.BL.Dtos.Product;
public record ProductWithCategoryDTO(int Id, string Name, string Image, int Quantity, double Price, CategoryReadDTO Category);