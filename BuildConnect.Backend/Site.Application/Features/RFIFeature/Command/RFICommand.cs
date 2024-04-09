using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.RFIFeature.Command;

public class CreateRFICommand : IRequest<Guid>
{
    public Guid Assignee { get; set; }
    public Guid FileId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public RFIStatus Status { get; set; }
    public Guid SiteId { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
}

// Command to start a new RFIChat
public class StartRFIChatCommand : IRequest<Guid>
{
    public Guid FileDetailId { get; set; } // Ties back to the image location
    public Guid StartedByUserId { get; set; } // ID of the user starting the chat
    public string InitialMessageContent { get; set; } // Initial message to start the chat
    public RFIMessageType InitialMessageType { get; set; } // Is it text or voice?
}

// Command to send a message to an existing RFIChat
public class SendMessageToRFIChatCommand : IRequest<Guid>
{
    public Guid RFIChatId { get; set; } // Which chat to send the message to
    public Guid SentByUserId { get; set; } // ID of the user sending the message
    public string Content { get; set; } // The message content itself
    public RFIMessageType MessageType { get; set; } // Is it text or voice?
}





