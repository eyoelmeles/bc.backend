using MediatR;
using Site.Application.Common.Interface;

namespace Site.Application.Features.InspectionFeature.Command;

public class DeleteInspectionCommandHandler : IRequestHandler<DeleteInspectionCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteInspectionCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteInspectionCommand request, CancellationToken cancellationToken)
    {


        var inspection = await _context.Inspections.FindAsync(request.Id);
        _context.Inspections.Remove(inspection);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
