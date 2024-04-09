using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.FoldersFeature.Command;

public class CreateFolderCommandHandler : IRequestHandler<CreateFolderCommand, FolderDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateFolderCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FolderDto> Handle(CreateFolderCommand request, CancellationToken cancellationToken)
    {
        var folder = new Folder
        {
            Name = request.Name,
            SiteId = request.SiteId
        };

        _context.Folders.Add(folder);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<FolderDto>(folder);
    }
}
