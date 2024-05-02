// using Site.Domain.Common;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace Site.Domain.Entity;

// public class ActivityLog: BaseModel
// {
//     [ForeignKey(nameof(User))]
//     public Guid UserId { get; set; }
//     public DateTime Timestamp { get; set; }
//     public string ActionType { get; set; }
//     public string Entity { get; set; }
//     public string Description { get; set; }
// }

// public class ActivityLogDTO
// {
//     public Guid UserId { get; set; }
//     public DateTime Timestamp { get; set; }
//     public string ActionType { get; set; }
//     public string Entity { get; set; }
//     public string Description { get; set; }
// }
