
using MediatR;
using Site.Application.Common.Interface;

namespace Site.Application.Features.WorkItemFeature.Command;

public class DeleteWorkItemCommandHandler : IRequestHandler<DeleteWorkItemCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteWorkItemCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(DeleteWorkItemCommand request, CancellationToken cancellationToken)
    {
        var workItem = await _dbContext.WorkItems.FindAsync(request.Id);

        if (workItem == null)
            throw new KeyNotFoundException($"WorkItem with Id {request.Id} not found.");

        _dbContext.WorkItems.Remove(workItem);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}

