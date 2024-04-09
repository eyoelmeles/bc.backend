
using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity;

public class Schedule : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    [ForeignKey("Site")]
    public Guid SiteId { get; set; }

    [ForeignKey("Schedlue")]
    public Guid? ParentSchedule { get; set;}
    public bool Status { get; set; }
}

public class ScheduleDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public Guid SiteId { get; set; }
    public Guid? ParentSchedule { get; set; }
    public bool Status { get; set; }
}