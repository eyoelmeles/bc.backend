using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class Inspection : BaseModel
    {
        public string Description { get; set; }
        public string? Image { get; set; }
        public InspectionStatus? Status { get; set; }
        [ForeignKey("Schedule")]
        public Guid ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public bool isActiveForInspection { get; set; }
        public Guid AssignedToId { get; set; }
        public Guid? ApprovedById { get; set; }
        public Guid CreatedById { get; set; }
        public virtual User AssignedTo { get; set; }
        public virtual User ApprovedBy { get; set; }
        public virtual User CreatedBy { get;set; }
    }
    public enum InspectionStatus
    {
        Pass,
        Fail,
        NA,
    }

    public class InspectionDTO
    {
        public Guid Id { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public InspectionStatus? Status { get; set; }
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public bool isActiveForInspection { get; set; }
        public User AssignedTo { get; set; }
        public User ApprovedBy { get; set; }
        public User CreatedBy { get; set; }
    }
}
