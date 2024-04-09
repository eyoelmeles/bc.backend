using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;


namespace Site.Application.Features.RoleFeatures.Query;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllRolesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<string>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = Enum.GetNames(typeof(Rolez));
        return roles;
    }
}
