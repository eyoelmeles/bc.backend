
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ManPowerCostFeature.Query;


public class GetManPowerCostByWorkItemQueryHandler : IRequestHandler<GetManPowerCostsByWorkItemQuery, IEnumerable<ManPowerCostDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetManPowerCostByWorkItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ManPowerCostDTO>> Handle(GetManPowerCostsByWorkItemQuery request, CancellationToken cancellationToken)
    {
        var manPowerCosts = await _context.ManPowerCosts
    .Include(mpc => mpc.Labour)
    .Where(mpc => mpc.WorkItem == request.WorkItem)
    .ToListAsync(cancellationToken);


        return _mapper.Map<IEnumerable<ManPowerCostDTO>>(manPowerCosts);
    }
}
