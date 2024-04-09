using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.MaterialFeature.Command;

public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, MaterialDTO>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateMaterialCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<MaterialDTO> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = new Material
        {
            Name = request.Name,
            UnitOfMeasureId = request.UnitOfMeasureId
        };

        _context.Materials.Add(material);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<MaterialDTO>(material);
    }
}
