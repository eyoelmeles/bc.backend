using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ScheduleFeature.Query;

public class GetRootSchedulesQueryHandler : IRequestHandler<GetRootSchedules, IEnumerable<ScheduleDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRootSchedulesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ScheduleDTO>> Handle(GetRootSchedules request, CancellationToken cancellationToken)
    {
        var schedules = await _context.Schedules.Where(x => x.ParentSchedule == Guid.Empty).ToListAsync();
        var scheduleDTOs = _mapper.Map<IEnumerable<ScheduleDTO>>(schedules);
        return scheduleDTOs;
    }
}