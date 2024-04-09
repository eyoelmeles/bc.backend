using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.SiteFeatures.Query;

public class GetSitesByUserQueryHandler : IRequestHandler<GetSiteByUserQuery, IEnumerable<SiteDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    public GetSitesByUserQueryHandler(IApplicationDbContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<IEnumerable<SiteDTO>> Handle(GetSiteByUserQuery request, CancellationToken cancellationToken)
    {
        var sites = await _context.SiteUsers
            .Where(su => su.UserId == request.UserId)
            .Select(su => su.Site)
            .ToListAsync(cancellationToken);

        return sites.Select(site =>
        {
            var siteDto = _mapper.Map<SiteDTO>(site);
            siteDto.Logo = string.IsNullOrEmpty(site.Logo)
            ? $"/api/files/Site/default.png"
            : _fileService.GetFileUrl(site.Logo, "Site");

            return siteDto;
        });
    }


}