using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.AssignSiteUserFeature.Query;

public class GetUsersBySiteQuery : IRequest<IEnumerable<UserDTO>>
{
    public Guid SiteId { get; set; }
}

public class GetSitesByUserId : IRequest<IEnumerable<SiteDTO>>
{
    public Guid UserId { get; set; }
}
