using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Site.Application.Common.Interface;

namespace Site.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet("{folderName}/{fileName}"), Authorize]
    public async Task<IActionResult> GetFile(string folderName, string fileName)
    {
        var fileContents = await _fileService.GetFileAsync(fileName, folderName);
        if (fileContents == null)
            return NotFound();

        // Determine the content type for the file
        var fileType = Path.GetExtension(fileName).TrimStart('.').ToLower();
        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(fileName, out var contentType))
        {
            contentType = "application/octet-stream"; // Default MIME type
        }

        return File(Convert.FromBase64String(fileContents), contentType);
    }
}
