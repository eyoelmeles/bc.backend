using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class LabourForce : BaseModel
    {
        public string Position { get; set; }
        public int Count { get; set; }
        public Guid DailyReportId { get; set; }
    }

    public class LabourForceDTO
    {
        public Guid Id { get; set; }
        public string Position { get; set; }
        public int Count { get; set; }
    }
}
