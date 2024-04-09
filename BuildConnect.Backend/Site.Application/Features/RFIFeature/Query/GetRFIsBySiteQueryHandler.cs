using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.RFIFeature.Query;


public class GetRFIsBySiteQueryHandler : IRequestHandler<GetRFIsBySiteQuery, IEnumerable<RFIDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRFIsBySiteQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RFIDTO>> Handle(GetRFIsBySiteQuery request, CancellationToken cancellationToken)
    {
        var rfis = await _context.RFIs
            .Where(rfi => rfi.SiteId == request.SiteId)
            .ToListAsync(cancellationToken);

        var rfisDTO = _mapper.Map<IEnumerable<RFIDTO>>(rfis);

        return rfisDTO;
    }
}