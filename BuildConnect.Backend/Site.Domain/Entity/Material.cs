using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class Material : BaseModel
    {
        public string Name { get; set; }
        [ForeignKey(nameof(Lookup))]
        public Guid UnitOfMeasureId { get; set; }
        public virtual Lookup UnitOfMeasure { get; set; }
        public Guid SiteId { get; set; }
    }
    public class MaterialDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public Lookup UnitOfMeasure { get; set; }
        public Guid SiteId { get; set; }
    }
}
