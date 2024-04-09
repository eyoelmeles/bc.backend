using MediatR;


namespace Site.Application.Features.ChatFeature.Command;

public class SendTextMessageCommand : IRequest<Guid>
{
    public Guid SenderId { get; set; }
    public Guid ChatId { get; set; }
    public string Content { get; set; }
}

public class SendVoiceMessageCommand : IRequest<Guid>
{
    public Guid SenderId { get; set; }
    public Guid ChatId { get; set; }
    public string Base64VoiceData { get; set; }
}

public class EditMessageCommand : IRequest<bool>
{
    public Guid MessageId { get; set; }
    public string NewContent { get; set; }
    // Add other fields if needed, like FileUrl for updating attachments.
}

public class DeleteMessageCommand : IRequest<bool>
{
    public Guid MessageId { get; set; }
}