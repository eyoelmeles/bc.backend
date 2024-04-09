using MediatR;
using Site.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Application.Features.FoldersFeature.Command;

public class CreateFolderCommand: IRequest<FolderDto>
{
    public string Name { get; set; }
    public Guid SiteId { get; set; }
}
