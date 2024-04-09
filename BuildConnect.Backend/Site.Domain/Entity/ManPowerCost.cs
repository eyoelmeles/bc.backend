using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace Site.Domain.Entity
{
    public class ManPowerCost : BaseModel
    {
        [ForeignKey(nameof(Lookup))]
        public Guid LabourId { get; set; }
        public virtual Lookup Labour { get; set; }
        public int Count { get; set; }
        public decimal UnitFactor { get; set; }
        public decimal HourlyIndex { get; set; }
        [ForeignKey("WorkItem")]
        public Guid WorkItem { get; set; }
    }

    public class ManPowerCostDTO
    {
        public Guid Id { get; set; }
        public Guid LabourId { get; set; }
        public Lookup Labour { get; set; }
        public int Count { get; set; }
        public decimal UnitFactor { get; set; }
        public decimal HourlyIndex { get; set; }
        public Guid WorkItem { get; set; }
    }
}
