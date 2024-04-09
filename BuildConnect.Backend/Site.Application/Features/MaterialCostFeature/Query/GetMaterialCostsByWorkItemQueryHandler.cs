
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialCostFeature.Query;

public class GetMaterialCostByWorkItemQueryHandler : IRequestHandler<GetMaterialCostsByWorkItemQuery, IEnumerable<MaterialCostDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMaterialCostByWorkItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MaterialCostDTO>> Handle(GetMaterialCostsByWorkItemQuery request, CancellationToken cancellationToken)
    {
        var materialCosts = await _context.MaterialCosts
        .Include(mc => mc.Material)
        .Include(mc => mc.UnitOfMeasure)
        .Where(mc => mc.WorkItem == request.WorkItem)
        .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<MaterialCostDTO>>(materialCosts);
    }
}

