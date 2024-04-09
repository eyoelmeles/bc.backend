using Site.Domain.Common;

namespace Site.Domain.Entity;

public enum RFIMessageType
{
    Text,
    Voice
}
public class RFIChat : BaseModel
{
    public Guid FileDetailId { get; set; }
    public List<ChatMessage> Messages { get; set; }
    public Guid StartedByUserId { get; set; }
}
public class ChatMessage : BaseModel
{
    public Guid RFIChatId { get; set; }
    public RFIMessageType MessageType { get; set; }
    public string Content { get; set; }
    public Guid SentByUserId { get; set; }  // ID of the user who sent this message
    public DateTime Timestamp { get; set; } // When was the message sent
}
