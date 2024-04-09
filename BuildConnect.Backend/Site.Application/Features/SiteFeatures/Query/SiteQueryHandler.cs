using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.SiteFeatures.Query;

public class SiteQueryHandler : IRequestHandler<GetSiteQuery, SiteDTO>
{
    private readonly IApplicationDbContext _context;

    public SiteQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SiteDTO> Handle(GetSiteQuery request, CancellationToken cancellationToken)
    {
        var site = await _context.Sites.FindAsync(request.Id);

        if (site == null)
        {
            // Handle "not found" case
            throw new NotFoundException(nameof(Site), request.Id);
        }

        return new SiteDTO
        {
            Id = site.Id,
            Name = site.Name,
            Owner = site.Owner,
            Longitude = site.Longitude,
            Latitude = site.Latitude
        };
    }
}
