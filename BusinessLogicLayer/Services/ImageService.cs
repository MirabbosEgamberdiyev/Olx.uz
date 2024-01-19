

using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Services;

public class ImageService : ImageInterface
{

    public async Task<string> UploadAsync(IFormFile file, string folderName, string DomenNmae)
    {
        if(file == null) throw new ArgumentNullException("file");
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var path = Path.Combine(folderName, fileName);

        using (var stream  = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return DomenNmae + fileName;
    }

    public Task DeleteAsync(string url, string folderName)
    {
        throw new NotImplementedException();
    }

}
