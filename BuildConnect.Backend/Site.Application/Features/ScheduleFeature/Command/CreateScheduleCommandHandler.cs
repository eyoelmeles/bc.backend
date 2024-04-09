using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ScheduleFeature.Command;

public class CreateScheduleCommandHandler : IRequestHandler<CreateSchedlueCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateScheduleCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateSchedlueCommand request, CancellationToken cancellationToken)
    {
        var rootSchedule = new Schedule
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,  
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            SiteId = request.SiteId,
            ParentSchedule = request.ParentSchedule == null ? null : request.ParentSchedule,
        };

        _context.Schedules.Add(rootSchedule);
        await _context.SaveChangesAsync(cancellationToken);

        return rootSchedule.Id;
    }
}
