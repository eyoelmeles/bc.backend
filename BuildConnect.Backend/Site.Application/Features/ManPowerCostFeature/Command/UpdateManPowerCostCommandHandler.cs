using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.ManPowerCostFeature.Command;

public class UpdateManPowerCostCommandHandler : IRequestHandler<UpdateManPowerCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateManPowerCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateManPowerCostCommand request, CancellationToken cancellationToken)
    {
        var manPowerCost = await _context.ManPowerCosts.FindAsync(request.Id);

        if (manPowerCost == null)
        {
            // Handle not found, maybe throw an exception
            throw new NotFoundException(nameof(ManPowerCost), request.Id);
        }

        manPowerCost.LabourId = request.LabourId;
        manPowerCost.Count = request.Count;
        manPowerCost.UnitFactor = request.UnitFactor;
        manPowerCost.HourlyIndex = request.HourlyIndex;
        manPowerCost.WorkItem = request.WorkItem;

        await _context.SaveChangesAsync(cancellationToken);

        return manPowerCost.Id;
    }
}
