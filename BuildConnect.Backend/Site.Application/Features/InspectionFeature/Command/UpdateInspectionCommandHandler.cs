using MediatR;
using Site.Application.Common.Interface;
using Site.Application.Features.LookupFeature.Command;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;


namespace Site.Application.Features.InspectionFeature.Command;

public class UpdateInspectionCommandHandler : IRequestHandler<UpdateInspectionCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateInspectionCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Guid> Handle(UpdateInspectionCommand request, CancellationToken cancellationToken)
    {
        var inspection = await _context.Inspections.FindAsync(request.Id);
        if (inspection == null)
        {
            throw new NotFoundException(nameof(Inspection), request.Id);
        }
        inspection.Description = request.Description ?? inspection.Description;
        inspection.Status = request.Status == null ? null : request.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return inspection.Id;
    }
}
