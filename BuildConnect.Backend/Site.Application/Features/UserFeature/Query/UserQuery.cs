using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.UserFeature.Query;

public class GetUserByIdQuery : IRequest<UserDTO>
{
    public Guid Id { get; set; }
}

public class GetUserBySiteIdQuery : IRequest<IEnumerable<UserDTO>>
{
    public Guid SiteId { get; set; }
}

public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
{
}

public class GetAllRolesQuery : IRequest<IEnumerable<string>>
{
}

public class GetAllUsersByRolesQuery : IRequest<IEnumerable<UserDTO>>
{
    public Role role { get; set; }
}