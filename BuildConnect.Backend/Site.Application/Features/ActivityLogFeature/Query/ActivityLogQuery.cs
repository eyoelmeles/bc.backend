using MediatR;
using Site.Domain.Common;
using Site.Domain.Entity;

namespace Site.Application.Features.ActivityLogFeature.Query;

public class GetUserActivitiesQuery : IRequest<PaginatedResult<ActivityLog>>
{
    public Guid UserId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

