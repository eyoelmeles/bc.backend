using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.LookupFeature.Query;

public class GetLookupsBySiteQueryHandler : IRequestHandler<GetLookupsBySite, IEnumerable<LookupDTO>>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLookupsBySiteQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<LookupDTO>> Handle(GetLookupsBySite request, CancellationToken cancellationToken)
    {
        var lookups = await _context.Lookups.Where((lookup) => lookup.SiteId == request.SiteId).ToListAsync(cancellationToken);
        var lookupsDTO = _mapper.Map<IEnumerable<LookupDTO>>(lookups);
        return lookupsDTO;
    }
}
