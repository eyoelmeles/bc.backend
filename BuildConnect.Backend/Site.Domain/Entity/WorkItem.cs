using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace Site.Domain.Entity
{
    public class WorkItem : BaseModel
    {
        public string Name { get; set; }
        [ForeignKey(nameof(Lookup))]
        public Guid UnitId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }

        [ForeignKey(nameof(Schedule))]
        public Guid ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        [ForeignKey(nameof(ManPowerCost))]
        public Guid? ManPowerCostId { get; set; }
        public virtual ManPowerCost? ManPowerCost { get; set; }

        [ForeignKey(nameof(EquipmentCost))]
        public Guid? EquipmentCostId { get; set; }
        public virtual EquipmentCost? EquipmentCost { get; set; }

        [ForeignKey(nameof(MaterialCost))]
        public Guid? MaterialCostId { get; set; }
        public virtual MaterialCost? MaterialCost { get; set; }

        public virtual Lookup Unit { get; set; }
    }

    public class WorkItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Lookup Unit { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public Guid ScheduleId { get; set; }
        public Guid? MaterialCostId { get; set; }
        public Guid? EquipmentCostId { get; set; }
        public Guid? ManPowerCostId { get; set; }
    }
}
