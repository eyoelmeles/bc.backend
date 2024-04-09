using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialCostFeature.Query;

public class GetMaterialCostsByWorkItemQuery : IRequest<IEnumerable<MaterialCostDTO>>
{
    public Guid WorkItem { get; set; }
}
