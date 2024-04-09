
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialCostFeature.Command;

public class UpdateMaterialCostCommandHandler : IRequestHandler<UpdateMaterialCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateMaterialCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateMaterialCostCommand request, CancellationToken cancellationToken)
    {
        var materialCost = await _context.MaterialCosts.FindAsync(request.Id);

        if (materialCost == null)
        {
            // Handle not found, maybe throw an exception
            throw new NotFoundException(nameof(MaterialCost), request.Id);
        }

        var material = await _context.Materials.FirstOrDefaultAsync(m => m.Id == request.MaterialId, cancellationToken);
        if (material == null)
        {
            // Handle not found, maybe throw an exception
            throw new NotFoundException(nameof(Material), request.MaterialId);
        }

        materialCost.MaterialId = material.Id;
        materialCost.UnitOfMeasureId = request.UnitOfMeasureId;
        materialCost.Quantity = request.Quantity;
        materialCost.Rate = request.Rate;
        materialCost.CostPerUnit = request.CostPerUnit;

        await _context.SaveChangesAsync(cancellationToken);

        return materialCost.Id;
    }
}
