using MediatR;

namespace Site.Application.Features.ChatFeature.Command;

public class CreateChatCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public Guid SiteId { get; set; }
    public List<Guid> ParticipantUserIds { get; set; }
}

public class EditChatCommand : IRequest<bool>
{
    public Guid ChatId { get; set; }
    public string NewName { get; set; }
}

public class DeleteChatCommand : IRequest<bool>
{
    public Guid ChatId { get; set; }
}