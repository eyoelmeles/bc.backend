using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ScheduleFeature.Query;

public class GetChildSchedulesQueryHandler : IRequestHandler<GetChildSchedules, IEnumerable<ScheduleDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetChildSchedulesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ScheduleDTO>> Handle(GetChildSchedules request, CancellationToken cancellationToken)
    {
        var schedules = await _context.Schedules.Where(x => x.ParentSchedule == request.Id).ToListAsync();
        var scheduleDTOs = _mapper.Map<IEnumerable<ScheduleDTO>>(schedules);
        return scheduleDTOs;
    }
}
