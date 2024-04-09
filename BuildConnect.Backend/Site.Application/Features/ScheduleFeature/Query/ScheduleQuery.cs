using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.ScheduleFeature.Query;

public class GetAllSchedules : IRequest<IEnumerable<ScheduleDTO>>
{
    public Guid SiteId { get; set; }
}
public class GetChildSchedules : IRequest<IEnumerable<ScheduleDTO>>
{
    public Guid Id { get; set; }
}

public class GetRootSchedules : IRequest<IEnumerable<ScheduleDTO>>
{
}