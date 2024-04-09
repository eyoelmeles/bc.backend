using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class RFIUser: BaseModel
    {
        [ForeignKey(nameof(RFI))]
        public Guid RFIId { get; set; }
        [ForeignKey(nameof(User))]
        public Guid AssignedUserId { get; set; }
        public virtual RFI RFI { get; set; }
        public virtual User AssignedUser { get; set; }
    }
}
