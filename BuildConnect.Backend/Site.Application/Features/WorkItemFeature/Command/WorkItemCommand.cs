using MediatR;

namespace Site.Application.Features.WorkItemFeature.Command;

public class CreateWorkItemCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public Guid Unit { get; set; }
    public int Rate {  get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public Guid ScheduleId { get; set; }
}

public class UpdateWorkItemCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ScheduleId { get; set; }
}

public class DeleteWorkItemCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}