using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class MaterialCost : BaseModel
    {
        [ForeignKey(nameof(Material))]
        public Guid MaterialId { get; set; }
        public virtual Material Material { get; set; }
        [ForeignKey(nameof(Lookup))]
        public Guid UnitOfMeasureId { get; set; }
        public virtual Lookup UnitOfMeasure { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal CostPerUnit { get; set; }
        [ForeignKey(nameof(WorkItem))]
        public Guid WorkItem { get; set; }
    }


    public class MaterialCostDTO
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public Material Material { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public Lookup UnitOfMeasure { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal CostPerUnit { get; set; }
        public Guid WorkItem { get; set; }
    }
}
