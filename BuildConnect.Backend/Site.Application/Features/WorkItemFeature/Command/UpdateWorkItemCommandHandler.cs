using MediatR;
using Site.Application.Common.Interface;

namespace Site.Application.Features.WorkItemFeature.Command;

public class UpdateWorkItemCommandHandler : IRequestHandler<UpdateWorkItemCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateWorkItemCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(UpdateWorkItemCommand request, CancellationToken cancellationToken)
    {
        var workItem = await _dbContext.WorkItems.FindAsync(request.Id);

        if (workItem == null)
            throw new KeyNotFoundException($"WorkItem with Id {request.Id} not found.");

        workItem.Name = request.Name;
        workItem.Description = request.Description;
        workItem.ScheduleId = request.ScheduleId;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return workItem.Id;
    }
}
