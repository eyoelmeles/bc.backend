using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.InspectionFeature.Command;

public class CreateInspectionCommandHandler : IRequestHandler<CreateInspectionCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateInspectionCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateInspectionCommand request, CancellationToken cancellationToken)
    {
        var inspection = new Inspection
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            ScheduleId = request.ScheduleId,
            Status = null,
            Image = null,
            AssignedToId = request.AssignedUserId,
            CreatedById = request.CreatedById,
        };

        _context.Inspections.Add(inspection);
        await _context.SaveChangesAsync(cancellationToken);

        return inspection.Id;
    }
}
