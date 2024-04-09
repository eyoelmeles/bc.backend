using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.InspectionFeature.Query;

public class GetInspectionByScheduleQueryHandler : IRequestHandler<GetInspectionBySchedule, IEnumerable<InspectionDTO>>
{
    private readonly IApplicationDbContext _context;

    public GetInspectionByScheduleQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InspectionDTO>> Handle(GetInspectionBySchedule request, CancellationToken cancellationToken)
    {
        return await _context.Inspections
            .Where(i => i.ScheduleId == request.ScheduleId)
            .Select(i => new InspectionDTO
            {
                Id = i.Id,
                Description = i.Description,
                Status = i.Status.HasValue ? i.Status.Value : InspectionStatus.NA, // Handle the nullable status here
                ScheduleId = i.ScheduleId,
                Schedule = i.Schedule
            })
            .ToListAsync(cancellationToken);
    }
}
