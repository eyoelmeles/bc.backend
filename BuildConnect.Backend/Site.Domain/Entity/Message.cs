using Site.Domain.Common;
using System;

namespace Site.Domain.Entity;

public class Message : BaseModel
{
    public Guid ChatId { get; set; } // Foreign key to the Chat
    public Chat Chat { get; set; }   // Navigation property to the Chat
    public Guid SenderId { get; set; } // Foreign key to the User who sent the message
    public User Sender { get; set; }   // Navigation property to the User
    public MessageType Type { get; set; }
    public string Content { get; set; } // For text messages
    public string? FileUrl { get; set; } // For voice, photo, and video messages
}

public enum MessageType
{
    Text,
    Voice,
    Photo,
    Video
}