using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Application.Features.LookupFeature.Query;
using Site.Domain.Entity;

namespace Site.Application.Features.UserFeature.Query;

internal class GetRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<string>>
{
    private readonly IApplicationDbContext _context;

    public GetRolesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }
    public async Task<IEnumerable<string>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = Enum.GetNames(typeof(Rolez));
        return roles;
    }
}
