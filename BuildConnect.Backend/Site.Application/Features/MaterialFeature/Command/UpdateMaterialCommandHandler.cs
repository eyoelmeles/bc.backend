using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;


namespace Site.Application.Features.MaterialFeature.Command;

public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, MaterialDTO>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateMaterialCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<MaterialDTO> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _context.Materials.FindAsync(request.Id);

        if (material == null)
        {
            throw new NotFoundException(nameof(Material), "Material Not found");
        }

        material.Name = request.Name ?? material.Name;
        material.UnitOfMeasureId = request.UnitOfMeasureId ?? material.UnitOfMeasureId;

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MaterialDTO>(material);
    }
}
