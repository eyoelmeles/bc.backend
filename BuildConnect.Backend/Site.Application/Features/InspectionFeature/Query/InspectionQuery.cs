using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.InspectionFeature.Query;

public class GetInspection : IRequest<InspectionDTO>
{
    public Guid Id { get; set; }
}

public class GetInspections : IRequest<IEnumerable<InspectionDTO>>
{
    public Guid SiteId { get; set; }
}

public class GetInspectionByStatus : IRequest<IEnumerable<InspectionDTO>>
{
    public InspectionStatus Status { get; set; }
}

public class GetInspectionBySchedule : IRequest<IEnumerable<InspectionDTO>>
{
    public Guid ScheduleId { get; set; }
}