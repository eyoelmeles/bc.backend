using MediatR;

namespace Site.Application.Features.ActivityLogFeature.Command;

public class CreateActivityLogCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string ActionType { get; set; }
    public string Entity { get; set; }
    public string Description { get; set; }
}
