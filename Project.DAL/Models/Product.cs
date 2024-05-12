using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [MinLength(3)]
    [MaxLength(500)]
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Image { get; set; } = string.Empty;
    [Required]
    [Range(0,int.MaxValue)]
    public int Quantity { get; set; }
    [Required]
    [Range(0.1, double.MaxValue)]
    public double Price { get; set; }

    [Required]
    [ForeignKey("Category")]
    public int Categoryid { get; set; }

    public Category Category { get; set; } = null!;

}
