using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.EquipmentCostFeature.Command;

public class CreateEquipmentCostCommandHandler : IRequestHandler<CreateEquipmentCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateEquipmentCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateEquipmentCostCommand request, CancellationToken cancellationToken)
    {
        var equipmentCost = new EquipmentCost
        {
            EquipmentId = request.EquipmentId,
            Count = request.Count,
            UnitFactor = request.UnitFactor,
            HourlyRental = request.HourlyRental,
            WorkItem = request.WorkItem
        };

        _context.EquipmentCosts.Add(equipmentCost);
        await _context.SaveChangesAsync(cancellationToken);

        return equipmentCost.Id;
    }
}

