using System.ComponentModel.DataAnnotations.Schema;
using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class Payment : BaseModel
    {
        [ForeignKey(nameof(Payment))]
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

    public class PaymentDTO
    {
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
