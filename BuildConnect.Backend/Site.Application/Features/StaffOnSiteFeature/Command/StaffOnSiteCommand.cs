using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.StaffOnSiteFeature.Command;

public class CreateStaffOnSiteCommand : IRequest<Guid>
{
    public string Position { get; set; }
    public int Count { get; set; }
}

public class UpdateStaffOnSiteCommand : IRequest<StaffOnSiteDTO>
{
    public Guid Id { get; set; }
    public string Position { get; set; }
    public int Count { get; set; }
    public string? Image { get; set; }
}

public class DeleteStaffOnSiteCommand : IRequest
{
    public Guid Id { get; set; }
}
