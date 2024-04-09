using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.RoleFeatures.Query;

public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRoleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FindAsync(request.Id);

        if (role == null)
        {
            throw new NotFoundException(nameof(Role), request.Id);
        }

        return _mapper.Map<RoleDto>(role);
    }
}
