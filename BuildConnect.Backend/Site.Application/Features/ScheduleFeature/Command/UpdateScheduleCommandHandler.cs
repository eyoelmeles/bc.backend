using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.ScheduleFeature.Command;

public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateScheduleCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Guid> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await _context.Schedules.FindAsync(request.Id);
        if (schedule == null)
        {
            throw new NotFoundException(nameof(Schedule), request.Id);
        }
        schedule.Name = request.Name ?? schedule.Name;
        schedule.Description = request.Description ?? schedule.Description;
        schedule.FromDate = request.FromDate ?? schedule.FromDate;
        schedule.ToDate = request.ToDate ?? schedule.ToDate;

        await _context.SaveChangesAsync(cancellationToken);

        return schedule.Id;
    }
}
