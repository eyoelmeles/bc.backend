using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.LabourForceFeatures.Command;

public class CreateLabourForceCommand : IRequest<Guid>
{
    public string Position { get; set; }
    public int Count { get; set; }

}
