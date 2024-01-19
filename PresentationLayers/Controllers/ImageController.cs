using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController(ImageInterface imageInterface,
                            IWebHostEnvironment hostEnvironment,
                            IConfiguration configuration) : ControllerBase
{
    private readonly ImageInterface _imageInterface = imageInterface;
    private readonly IWebHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IConfiguration _configuration = configuration;

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var folderName = Path.Combine(_hostEnvironment.WebRootPath, "images");
        var domenName = _configuration["Domain"]!;
        var result = await _imageInterface.UploadAsync(file, folderName, domenName);
        return Ok(result);
    }
}
