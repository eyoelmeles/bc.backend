using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.LookupFeature.Query;

public class GetLookup : IRequest<LookupDTO>
{
    public Guid Id { get; set; }
}

public class GetLookupsBySite : IRequest<IEnumerable<LookupDTO>>
{
    public Guid SiteId { get; set; }
}

public class GetLookupByLookupType : IRequest<IEnumerable<LookupDTO>>
{
    public LookupType LookupType { get; set; }
    public Guid SiteId { get; set; }
}

public class GetLookupTypes : IRequest<IEnumerable<string>>
{
}