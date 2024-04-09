using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialCostFeature.Command;

public class DeleteMaterialCostCommandHandler : IRequestHandler<DeleteMaterialCostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteMaterialCostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteMaterialCostCommand request, CancellationToken cancellationToken)
    {
        var materialCost = await _context.MaterialCosts.FindAsync(request.Id);

        if (materialCost == null)
        {
            // Handle not found, maybe throw an exception
            throw new NotFoundException(nameof(MaterialCost), request.Id);
        }

        _context.MaterialCosts.Remove(materialCost);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}

