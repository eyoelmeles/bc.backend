using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.InspectionFeature.Query;

public class GetInspectionsQueryHandler : IRequestHandler<GetInspections, IEnumerable<InspectionDTO>>
{
    private readonly IApplicationDbContext _context;

    public GetInspectionsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InspectionDTO>> Handle(GetInspections request, CancellationToken cancellationToken)
    {
        return await _context.Inspections
            .Where(i => i.Schedule.SiteId == request.SiteId)
            .Select(i => new InspectionDTO
            {
                Id = i.Id,
                Description = i.Description,
                Status = i.Status.Value,  // Ensure you have value here, otherwise handle nullable case
                ScheduleId = i.ScheduleId,
                Schedule = i.Schedule
            })
            .ToListAsync(cancellationToken);
    }
}
