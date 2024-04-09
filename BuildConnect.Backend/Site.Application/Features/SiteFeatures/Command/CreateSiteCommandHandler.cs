using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Command;
public class CreateSiteHandler : IRequestHandler<CreateSiteCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public CreateSiteHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;

        _fileService = fileService;
    }

    public async Task<Guid> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
    {
        byte[] fileBytes;

        using (var memoryStream = new MemoryStream())
        {
            await request.Logo.CopyToAsync(memoryStream);
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
        var fileName = await _fileService.SaveFileAsync(fileBytes, fileExtension, "Site");

        var site = new SiteModel
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Owner = request.Owner,
            Longitude = request.Longitude,
            Latitude = request.Latitude,
            Logo = fileName,
            Supervisor = request.Supervisor,
            Client = request.Client,
            Contractor = request.Contractor,
        };

        await _context.Sites.AddAsync(site, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return site.Id;
    }
}
