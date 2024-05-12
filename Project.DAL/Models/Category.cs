using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [MinLength(2)]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Product> Products { get; set; } = null!;
}
