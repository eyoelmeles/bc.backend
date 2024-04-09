using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Application.Features.MaterialFeatures.Query;
using Site.Domain.Entity;


namespace Site.Application.Features.MaterialFeature.Query;

public class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterialsQuery, IEnumerable<MaterialDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMaterialsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MaterialDTO>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
    {
        var materials = await _context.Materials
    .Include(mc => mc.UnitOfMeasure)
    .ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MaterialDTO>>(materials);
    }
}
