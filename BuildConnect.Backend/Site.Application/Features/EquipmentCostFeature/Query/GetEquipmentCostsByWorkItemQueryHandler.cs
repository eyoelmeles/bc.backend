using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.EquipmentCostFeature.Query;

public class GetEquipmentCostByWorkItemQueryHandler : IRequestHandler<GetEquipmentCostsByWorkItemQuery, IEnumerable<EquipmentCostDTO>>
{
    private readonly IApplicationDbContext _context; // Your EF Core context
    private readonly IMapper _mapper;

    public GetEquipmentCostByWorkItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EquipmentCostDTO>> Handle(GetEquipmentCostsByWorkItemQuery request, CancellationToken cancellationToken)
    {
        //var equipmentCosts = await _context.EquipmentCosts
        //    .Where(ec => ec.WorkItem == request.WorkItem)
        //    .ToListAsync(cancellationToken);
        var equipmentCosts = await _context.EquipmentCosts
    .Include(mpc => mpc.Equipment)
    .Where(mpc => mpc.WorkItem == request.WorkItem)
    .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<EquipmentCostDTO>>(equipmentCosts);
    }
}
