using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class EquipmentCost : BaseModel
    {
        [ForeignKey(nameof(Lookup))]
        public Guid EquipmentId { get; set; }
        public virtual Lookup Equipment { get; set; }
        public int Count { get; set; }
        public decimal UnitFactor { get; set; }
        public decimal HourlyRental { get; set; }
        [ForeignKey("WorkItem")]
        public Guid WorkItem { get; set; }
    }

    public class EquipmentCostDTO
    {
        public Guid Id { get; set; }
        public Guid EquipmentId { get; set; }
        public int Count { get; set; }
        public decimal UnitFactor { get; set; }
        public decimal HourlyRental { get; set; }
        public Lookup Equipment { get; set; }
        public Guid WorkItem { get; set; }
    }
}
