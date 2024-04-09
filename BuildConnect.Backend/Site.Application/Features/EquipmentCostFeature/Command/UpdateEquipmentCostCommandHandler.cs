

using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.EquipmentCostFeature.Command;

public class UpdateEquipmentCostCommandHandler : IRequestHandler<UpdateEquipmentCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateEquipmentCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateEquipmentCostCommand request, CancellationToken cancellationToken)
    {
        var equipmentCost = await _context.EquipmentCosts.FindAsync(request.Id);

        if (equipmentCost == null)
        {
            // Handle not found, maybe throw an exception
            throw new NotFoundException(nameof(EquipmentCost), request.Id);
        }

        equipmentCost.EquipmentId = request.EquipmentId;
        equipmentCost.Count = request.Count;
        equipmentCost.UnitFactor = request.UnitFactor;
        equipmentCost.HourlyRental = request.HourlyRental;
        equipmentCost.WorkItem = request.WorkItem;

        await _context.SaveChangesAsync(cancellationToken);

        return equipmentCost.Id;
    }
}

