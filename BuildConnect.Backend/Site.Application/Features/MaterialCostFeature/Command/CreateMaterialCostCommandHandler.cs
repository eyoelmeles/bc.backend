

using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialCostFeature.Command;

public class CreateMaterialCostCommandHandler : IRequestHandler<CreateMaterialCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateMaterialCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateMaterialCostCommand request, CancellationToken cancellationToken)
    {
        var material = await _context.Materials.FirstOrDefaultAsync(m => m.Id == request.MaterialId, cancellationToken);
        if (material == null)
        {
            // Handle not found, maybe throw an exception
            throw new NotFoundException(nameof(Material), request.MaterialId);
        }

        var materialCost = new MaterialCost
        {
            MaterialId = material.Id,
            UnitOfMeasureId = request.UnitOfMeasureId,
            Quantity = request.Quantity,
            Rate = request.Rate,
            CostPerUnit = request.CostPerUnit,
            WorkItem = request.WorkItemId
        };

        _context.MaterialCosts.Add(materialCost);
        await _context.SaveChangesAsync(cancellationToken);

        return materialCost.Id;
    }
}

