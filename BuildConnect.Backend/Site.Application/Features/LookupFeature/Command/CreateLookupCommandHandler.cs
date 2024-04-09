using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.LookupFeature.Command;

public class CreateLookupCommandHandler : IRequestHandler<CreateLookupCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateLookupCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateLookupCommand request, CancellationToken cancellationToken)
    {
        var lookup = new Lookup
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            LookupType = request.LookupType,
            Description = request.Description,
            SiteId = request.SiteId,
        };
       
        _context.Lookups.Add(lookup);
        await _context.SaveChangesAsync(cancellationToken);

        return lookup.Id;
    }
}