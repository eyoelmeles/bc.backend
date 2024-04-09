using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity;

public class Sync : BaseModel
{
    public Guid LocalId { get; set; }
    public Guid ServerId { get; set; }
    public DateTime Timestamp { get; set; }
    public SyncStatus Status { get; set; }
    public string EntityName { get; set; }
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public int RetryCount { get; set; }
}

public enum SyncStatus
{
    pending,
    success,
    failed
}
