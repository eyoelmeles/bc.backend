using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.InspectionFeature.Query;

public class GetInspectionByStatusHandler : IRequestHandler<GetInspectionByStatus, IEnumerable<InspectionDTO>>
{
    private readonly IApplicationDbContext _context;

    public GetInspectionByStatusHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InspectionDTO>> Handle(GetInspectionByStatus request, CancellationToken cancellationToken)
    {
        return await _context.Inspections
            .Where(i => i.Status == request.Status)
            .Select(i => new InspectionDTO
            {
                Id = i.Id,
                Description = i.Description,
                Status = i.Status,
                ScheduleId = i.ScheduleId,
                Schedule = i.Schedule
            })
            .ToListAsync(cancellationToken);
    }
}



