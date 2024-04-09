using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.WorkItemFeature.Query;

public class GetAllWorkItemsByScheduleQueryHandler : IRequestHandler<GetAllWorkItemsByScheduleQuery, IEnumerable<WorkItemDTO>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllWorkItemsByScheduleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WorkItemDTO>> Handle(GetAllWorkItemsByScheduleQuery request, CancellationToken cancellationToken)
    {
        var workItems = await _dbContext.WorkItems
                        .Where(wi => wi.ScheduleId == request.ScheduleId)
                        .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<WorkItemDTO>>(workItems);
    }
}
