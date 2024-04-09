using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.EquipmentCostFeature.Query;

public class GetEquipmentCostsByWorkItemQuery : IRequest<IEnumerable<EquipmentCostDTO>>
{
    public Guid WorkItem { get; set; }
}
