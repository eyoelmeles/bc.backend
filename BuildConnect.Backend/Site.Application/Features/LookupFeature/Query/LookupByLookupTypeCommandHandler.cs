using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.LookupFeature.Query;

public class LookupByLookupTypesHandler : IRequestHandler<GetLookupByLookupType, IEnumerable<LookupDTO>>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LookupByLookupTypesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<LookupDTO>> Handle(GetLookupByLookupType request, CancellationToken cancellationToken)
    {
        var lookups = await _context.Lookups.Where(x => x.LookupType == request.LookupType && x.SiteId == request.SiteId).ToListAsync();
        var lookupDTOs = _mapper.Map<IEnumerable<LookupDTO>>(lookups);
        return lookupDTOs;
    }
}
