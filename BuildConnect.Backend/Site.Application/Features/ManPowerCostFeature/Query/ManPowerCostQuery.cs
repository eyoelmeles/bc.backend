using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.ManPowerCostFeature.Query;

public class GetManPowerCostsByWorkItemQuery : IRequest<IEnumerable<ManPowerCostDTO>>
{
    public Guid WorkItem { get; set; }
}
