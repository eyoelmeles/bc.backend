using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.AssignSiteUserFeature.Command;

public class CreateSiteUserCommand : IRequest<SiteUserDTO>
{
    public Guid SiteId { get; set; }
    public List<Guid> UsersId { get; set; }
    public Role Role { get; set; }
}

public class UpdateSiteUserCommand : IRequest<SiteUserDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

public class DeleteSiteUserCommand : IRequest
{
    public Guid Id { get; set; }
}

