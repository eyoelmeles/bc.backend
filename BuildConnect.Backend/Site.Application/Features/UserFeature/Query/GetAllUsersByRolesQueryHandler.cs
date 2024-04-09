using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.UserFeature.Query;

public class GetAllUsersByRolesQueryHandler : IRequestHandler<GetAllUsersByRolesQuery, IEnumerable<UserDTO>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllUsersByRolesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> Handle(GetAllUsersByRolesQuery request, CancellationToken cancellationToken)
    {
        var usersWithGivenRole = await _dbContext.Users
                                .Where(user => user.Role == request.role)
                                .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<UserDTO>>(usersWithGivenRole);
    }
}
