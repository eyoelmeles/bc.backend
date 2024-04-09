using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.WorkItemFeature.Command;

public class CreateWorkItemCommandHandler : IRequestHandler<CreateWorkItemCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateWorkItemCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateWorkItemCommand request, CancellationToken cancellationToken)
    {
        var workItem = new WorkItem
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Rate = request.Rate,
            Quantity = request.Quantity,
            UnitId = request.Unit,
            ScheduleId = request.ScheduleId
        };

        _dbContext.WorkItems.Add(workItem);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return workItem.Id;
    }
}