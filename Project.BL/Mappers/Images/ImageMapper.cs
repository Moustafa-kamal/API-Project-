using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Project.BL.Mappers.Images;

public class ImageMapper : IImageMapper
{
    private readonly IWebHostEnvironment _env;

    public ImageMapper(IWebHostEnvironment env)
    {
        _env = env;
    }
    public string ConvertImage(IFormFile image)
    {
        string imageName = Guid.NewGuid().ToString() + ".png";
        var folderPath = Path.Combine(_env.WebRootPath, "Images");
        Directory.CreateDirectory(folderPath);

        string fullpath =Path.Combine(folderPath, imageName);

        using (var fs = new FileStream(fullpath,FileMode.Create))
        {
            image.CopyToAsync(fs);
        }
        
        return imageName;
    }
}
