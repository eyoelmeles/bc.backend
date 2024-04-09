using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.LabourForceFeatures.Command;

public class CreateLabourForceCommandCommandHandler : IRequestHandler<CreateLabourForceCommand, Guid>
{

    private readonly IApplicationDbContext _context;

    public CreateLabourForceCommandCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateLabourForceCommand request, CancellationToken cancellationToken)
    {
        var labourForce = new LabourForce
        {
            Position = request.Position,
            Count = request.Count
        };
        _context.LabourForces.Add(labourForce);
        await _context.SaveChangesAsync(cancellationToken);
        return labourForce.Id;
    }
}