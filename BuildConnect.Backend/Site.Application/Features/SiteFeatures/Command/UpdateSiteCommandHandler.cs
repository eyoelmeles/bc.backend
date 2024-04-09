using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Command
{
    public class UpdateSiteCommandHandler : IRequestHandler<UpdateSiteCommand, SiteDTO>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSiteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SiteDTO> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
        {
            var site = await _context.Sites.FindAsync(request.Id);

            if (site == null)
            {
                // Handle "not found" case
                throw new NotFoundException(nameof(Site), request.Id);
            }

            site.Name = request.Name;
            site.Owner = request.Owner;
            site.Longitude = request.Longitude;
            site.Latitude = request.Latitude;

            await _context.SaveChangesAsync(cancellationToken);

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
}
