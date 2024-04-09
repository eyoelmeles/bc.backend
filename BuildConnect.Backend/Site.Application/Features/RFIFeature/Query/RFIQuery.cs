using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.RFIFeature.Query;

public class GetRFIChatByFileDetailQuery : IRequest<RFIChat>
{
    public Guid FileDetailId { get; set; }
}

public class GetRFIsBySiteQuery : IRequest<IEnumerable<RFIDTO>>
{
    public Guid SiteId { get; set; }
}



