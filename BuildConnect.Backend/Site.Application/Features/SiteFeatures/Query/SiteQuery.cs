using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Query;

public class GetSiteQuery : IRequest<SiteDTO>
{
    public Guid Id { get; set; }
}
public class GetSiteByUserQuery : IRequest<IEnumerable<SiteDTO>>
{
    public Guid UserId { get; set; }
}

public class GetAllSitesQuery : IRequest<IEnumerable<SiteDTO>>
{
}