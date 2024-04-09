using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity;

public class Lookup: BaseModel
{
    public string Name { get; set; }
    public LookupType LookupType { get; set; }
    [ForeignKey(nameof(SiteModel))]
    public Guid SiteId { get; set; }
    public virtual SiteModel Site { get; set; }
    public string Description { get; set; }
}

public enum LookupType
{
    UnitOfMeasure,
    Material,
    Equipment,
    Labour,
    StaffOnSite,
    Weather
}

public class LookupDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public LookupType LookupType { get; set; }
    public Guid SiteId { get; set; }
    public string Description { get; set; }
}