using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class RFI: BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public RFIStatus Status { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(User))]
        public Guid Assignee { get; set; }
        [ForeignKey(nameof(SiteModel))]
        public Guid SiteId { get; set; }

        [ForeignKey(nameof(FileDetail))]
        public Guid Attachement { get; set; }
    }
    public enum RFIStatus
    {
        pending,
        declined,
        resolved,
    }
    public class RFIDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RFIStatus Status { get; set; }
        public DateTime Date { get; set; }
        public Guid SiteId { get; set; }

        public Guid Assignee { get; set; }

        public Guid Attachement { get; set; }
    }
}
