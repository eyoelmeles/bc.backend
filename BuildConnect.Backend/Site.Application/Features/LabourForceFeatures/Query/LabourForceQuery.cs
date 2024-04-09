using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.LabourForceFeatures.Query;

public class GetLabourForceQuery : IRequest<LabourForceDTO>
{
    public Guid Id { get; set; }
}

public class GetAllLabourForceQuery : IRequest<IEnumerable<LabourForceDTO>>
{
}