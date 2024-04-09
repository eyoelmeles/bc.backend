using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.AssignSiteUserFeature.Query
{
    public class GetSitesByUserQueryHandler : IRequestHandler<GetSitesByUserId, IEnumerable<SiteDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSitesByUserQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SiteDTO>> Handle(GetSitesByUserId request, CancellationToken cancellationToken)
        {
            return await _context.SiteUsers
                .Where(su => su.UserId == request.UserId)
                .Join(_context.Sites, su => su.SiteId, s => s.Id, (su, s) => s)
                .Select(s => new SiteDTO
                {
                    Id = s.Id,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    Name = s.Name,
                    Owner = s.Owner
                })
                .ToListAsync(cancellationToken);
        }
    }
}
