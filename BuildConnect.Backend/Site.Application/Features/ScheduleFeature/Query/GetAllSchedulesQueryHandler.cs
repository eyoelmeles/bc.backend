using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ScheduleFeature.Query;

public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedules, IEnumerable<ScheduleDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSchedulesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ScheduleDTO>> Handle(GetAllSchedules request, CancellationToken cancellationToken)
    {
        var schedules = await _context.Schedules.Where(x => x.SiteId == request.SiteId).ToListAsync();
        var scheduleDTOs = _mapper.Map<IEnumerable<ScheduleDTO>>(schedules);
        return scheduleDTOs;
    }
}
