using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;


namespace Site.Application.Features.LookupFeature.Command;

public class UpdateLookupCommandHandler : IRequestHandler<UpdateLookupCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateLookupCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Guid> Handle(UpdateLookupCommand request, CancellationToken cancellationToken)
    {
        var lookup = await _context.Lookups.FindAsync(request.Id);
        if (lookup == null)
        {
            throw new NotFoundException(nameof(Lookup), request.Id);
        }
        lookup.Name = request.Name ?? lookup.Name;
        lookup.Description = request.Description ?? lookup.Description;
        lookup.SiteId = request.SiteId ?? lookup.SiteId;

        await _context.SaveChangesAsync(cancellationToken);

        return lookup.Id;
    }
}
