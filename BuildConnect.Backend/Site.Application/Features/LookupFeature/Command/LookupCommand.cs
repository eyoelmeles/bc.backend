using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.LookupFeature.Command;

public class CreateLookupCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public LookupType LookupType { get; set; }
    public Guid SiteId { get; set; }
    public string Description { get; set; }

}

public class UpdateLookupCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public LookupType LookupType { get; set; }
    public Guid? SiteId { get; set; }
    public string Description { get; set; }
}

public class DeleteLookupCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}