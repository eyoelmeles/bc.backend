using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.RoleFeatures.Query;

public class GetRoleQuery : IRequest<RoleDto>
{
    public Guid Id { get; set; }
}

public class GetAllRolesQuery : IRequest<IEnumerable<string>>
{
}
