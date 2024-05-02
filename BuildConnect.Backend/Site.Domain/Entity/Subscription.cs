using System.ComponentModel.DataAnnotations.Schema;
using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class Subscription : BaseModel
    {
        [ForeignKey(nameof(SiteModel))]
        public Guid SiteId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    public class SubscriptionDTO
    {
        public Guid Id { get; set; }
        public Guid SiteId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
