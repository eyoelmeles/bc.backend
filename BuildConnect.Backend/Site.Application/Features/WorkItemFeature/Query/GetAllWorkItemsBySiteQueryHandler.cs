using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.WorkItemFeature.Query;

public class GetAllWorkItemsBySiteQueryHandler : IRequestHandler<GetAllWorkItemsBySiteQuery, IEnumerable<WorkItemDTO>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllWorkItemsBySiteQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WorkItemDTO>> Handle(GetAllWorkItemsBySiteQuery request, CancellationToken cancellationToken)
    {
        var workItems = await _dbContext.WorkItems
                        .Where(wi => wi.Schedule.SiteId == request.SiteId && wi.Schedule.Status == true)
                        .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<WorkItemDTO>>(workItems);
    }
}
