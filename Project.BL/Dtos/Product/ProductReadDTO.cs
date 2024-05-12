namespace Project.BL.Dtos.Product;
public record ProductReadDTO(int Id, string Name, string Image, int Quantity, double Price, int Categoryid);