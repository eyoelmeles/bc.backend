using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Application.Features.MaterialFeatures.Query;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Query;

public class GetAllSitesQueryHandler : IRequestHandler<GetAllSitesQuery, IEnumerable<SiteDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public GetAllSitesQueryHandler(IApplicationDbContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }
    public async Task<IEnumerable<SiteDTO>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
    {
        var sites = await _context.Sites.ToListAsync(cancellationToken);
        return sites.Select(site =>
        {
            var siteDto = _mapper.Map<SiteDTO>(site);
            siteDto.Logo = _fileService.GetFileUrl(site.Logo, "Site");
            return siteDto;
        });
    }
}

