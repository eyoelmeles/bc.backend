using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.EquipmentCostFeature.Command;

public class DeleteEquipmentCostCommandHandler : IRequestHandler<DeleteEquipmentCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteEquipmentCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteEquipmentCostCommand request, CancellationToken cancellationToken)
    {
        var equipmentCost = await _context.EquipmentCosts.FindAsync(request.Id);

        if (equipmentCost == null)
        {
            throw new NotFoundException(nameof(EquipmentCost), request.Id);
        }

        _context.EquipmentCosts.Remove(equipmentCost);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}

