using MediatR;
using Site.Application.Common.Interface;

namespace Site.Application.Features.ScheduleFeature.Command;

public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteScheduleCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
    {

        var schedule = await _context.Schedules.FindAsync(request.Id);
        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
