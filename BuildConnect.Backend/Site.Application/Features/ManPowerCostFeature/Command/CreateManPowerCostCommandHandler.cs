using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ManPowerCostFeature.Command;

public class CreateManPowerCostCommandHandler : IRequestHandler<CreateManPowerCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateManPowerCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateManPowerCostCommand request, CancellationToken cancellationToken)
    {
        var manPowerCost = new ManPowerCost
        {
            LabourId = request.LabourId,
            Count = request.Count,
            UnitFactor = request.UnitFactor,
            HourlyIndex = request.HourlyIndex,
            WorkItem = request.WorkItem
        };

        _context.ManPowerCosts.Add(manPowerCost);
        await _context.SaveChangesAsync(cancellationToken);

        return manPowerCost.Id;
    }
}

