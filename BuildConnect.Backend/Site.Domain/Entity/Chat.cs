using Site.Domain.Common;


namespace Site.Domain.Entity
{
    public class Chat: BaseModel
    {
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public ICollection<UserChat> UserChats { get; set; }
        public ICollection<Message> Messages { get; set; }
        public Guid SiteId { get; set; }
        public SiteModel Site { get; set; }
    }   

    public enum ChatType
    {
        Private, // One-on-one chat
        Group    // Group chat
    }

    public class UserChat : BaseModel
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }
    }

    public class ChatDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public ICollection<UserChat> UserChats { get; set; }
        public ICollection<Message> Messages { get; set; }
        public Guid SiteId { get; set; }
    }
}
