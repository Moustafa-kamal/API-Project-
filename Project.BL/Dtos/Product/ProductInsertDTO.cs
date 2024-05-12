using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace Project.BL.Dtos.Product;
public record ProductInsertDTO([Required]string Name, [Required] IFormFile Image, [Required] int Quantity, [Required] double Price, int Categoryid);