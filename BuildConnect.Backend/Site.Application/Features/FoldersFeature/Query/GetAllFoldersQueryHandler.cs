using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.FoldersFeature.Query;


public class GetAllFoldersQueryHandler : IRequestHandler<GetAllFoldersQuery, IEnumerable<FolderDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllFoldersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<FolderDto>> Handle(GetAllFoldersQuery request, CancellationToken cancellationToken)
    {
        var folders = await _context.Folders
            .Where(f => f.SiteId == request.SiteId)
            .ToListAsync(cancellationToken);

        var folderDtos = _mapper.Map<IEnumerable<FolderDto>>(folders);

        return folderDtos;
    }
}