using MediatR;
using Site.Application.Common.Interface;

namespace Site.Application.Features.LookupFeature.Command;

public class DeleteLookupCommandHandler : IRequestHandler<DeleteLookupCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteLookupCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteLookupCommand request, CancellationToken cancellationToken)
    {


        var lookup = await _context.Lookups.FindAsync(request.Id);
        _context.Lookups.Remove(lookup);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
