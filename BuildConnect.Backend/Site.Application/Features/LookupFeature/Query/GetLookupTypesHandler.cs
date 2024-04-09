using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.LookupFeature.Query;

public class GetLookupTypesHandler : IRequestHandler<GetLookupTypes, IEnumerable<string>>
{

    private readonly IApplicationDbContext _context;

    public GetLookupTypesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }
    public async Task<IEnumerable<string>> Handle(GetLookupTypes request, CancellationToken cancellationToken)
    {
        var lookupTypes = Enum.GetNames(typeof(LookupType));
        return lookupTypes;
    }
}