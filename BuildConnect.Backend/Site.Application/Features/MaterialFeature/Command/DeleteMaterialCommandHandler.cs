using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialFeature.Command;

public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteMaterialCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _context.Materials.FindAsync(request.Id);

        if (material == null)
        {
            throw new NotFoundException(nameof(Material), "Material Not found");
        }

        _context.Materials.Remove(material);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
