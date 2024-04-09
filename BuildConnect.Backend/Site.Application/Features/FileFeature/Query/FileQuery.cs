using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.FileFeature.Query;


public class GetFileByFolderIdQuery : IRequest<IEnumerable<FileModelDTO>>
{
    public Guid FolderId { get; set; }
}
public class GetFileQuery : IRequest<FileModelDTO>
{
    public Guid Id { get; set; }
}
public class GetFileDetailQuery : IRequest<FileDetailDTO>
{
    public Guid Id { get; set; }
}
public class GetFileDetailByFileIdQuery : IRequest<IEnumerable<FileDetailDTO>>
{
    public Guid FileId { get; set; }

    public GetFileDetailByFileIdQuery(Guid fileId)
    {
        FileId = fileId;
    }
}


