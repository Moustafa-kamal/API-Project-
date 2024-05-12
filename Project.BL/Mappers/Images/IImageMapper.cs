using Microsoft.AspNetCore.Http;

namespace Project.BL.Mappers.Images;

public interface IImageMapper
{
    string ConvertImage(IFormFile image);
}
