using MediatR;
using Microsoft.AspNetCore.Http;

namespace Site.Application.Features.FileFeature.Command;

public class CreateFileCommand : IRequest<Guid>
{
    public Guid FolderId { get; set; }
    public string FileName { get; set; }
    public IFormFile File { get; set; }
}

public class AddFileCoordinateCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string File { get; set; }

}