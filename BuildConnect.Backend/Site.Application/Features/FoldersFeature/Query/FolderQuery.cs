using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.FoldersFeature.Query;

public class GetAllFoldersQuery : IRequest<IEnumerable<FolderDto>>
{
    public Guid SiteId { get; set; }
}

