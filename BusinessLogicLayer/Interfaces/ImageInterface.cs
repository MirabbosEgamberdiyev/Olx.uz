
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Interfaces;

public interface ImageInterface
{
    Task<string> UploadAsync(IFormFile file, string folderName, string DomenNmae);

    Task DeleteAsync(string url,  string folderName);


}
