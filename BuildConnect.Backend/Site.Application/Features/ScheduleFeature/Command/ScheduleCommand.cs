using MediatR;

namespace Site.Application.Features.ScheduleFeature.Command;

public class CreateSchedlueCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public Guid SiteId { get; set; }
    public Guid ParentSchedule { get; set; }
}


public class UpdateScheduleCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public Guid? ChildSchedlue { get; set; }
}


public class DeleteScheduleCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}