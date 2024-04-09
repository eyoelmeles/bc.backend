using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System.Text.RegularExpressions;

namespace Site.Application.Features.FileFeature.Command;

public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public CreateFileCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }
    public string GetFileTypeFromBase64(string base64DataUrl)
    {
        var match = Regex.Match(base64DataUrl, @"^data:image\/([a-zA-Z0-9]+);base64,");
        if (match.Success && match.Groups.Count > 1)
        {
            return match.Groups[1].Value;
        }
        return null;
    }
    public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        byte[] fileBytes;

        using (var memoryStream = new MemoryStream())
        {
            await request.File.CopyToAsync(memoryStream);
            fileBytes = memoryStream.ToArray();
        }

        // Detect file type using ImageSharp
        var format = Image.DetectFormat(fileBytes);

        // Check if the detected format is valid
        if (format == null)
        {
            throw new Exception("Invalid image format.");
        }


        var fileExtension = format.FileExtensions.FirstOrDefault();

        //var fileExtension = format.DefaultFileExtension;
        var fileName = await _fileService.SaveFileAsync(fileBytes, fileExtension, "SharedFiles");
        var newFile = new FileModel
        {
            FolderId = request.FolderId,
            FileName = request.FileName,
            File = fileName
        };

        _context.FileModels.Add(newFile);
        await _context.SaveChangesAsync(cancellationToken);

        return newFile.Id;
    }
}
