using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.ManPowerCostFeature.Command;

public class DeleteManPowerCostCommandHandler : IRequestHandler<DeleteManPowerCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteManPowerCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteManPowerCostCommand request, CancellationToken cancellationToken)
    {
        var manPowerCost = await _context.ManPowerCosts.FindAsync(request.Id);

        if (manPowerCost == null)
        {
            // Handle not found, maybe throw an exception
            throw new NotFoundException(nameof(ManPowerCost), request.Id);
        }

        _context.ManPowerCosts.Remove(manPowerCost);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}


