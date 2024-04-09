using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;

namespace Site.Application.Features.SiteFeatures.Command
{
    public class DeleteSiteCommandHandler : IRequestHandler<DeleteSiteCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSiteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSiteCommand request, CancellationToken cancellationToken)
        {
            var site = await _context.Sites.FindAsync(request.Id);

            if (site == null)
            {
                // Handle "not found" case
                throw new NotFoundException(nameof(Site), request.Id);
            }

            site.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
