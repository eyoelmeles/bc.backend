using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class StaffOnSite : BaseModel
    {
        public string Position { get; set; }
        public int Count { get; set; }
        public Guid DailyReportId { get; set; }
        public DailyReport DailyReport { get; set; }
    }

    public class StaffOnSiteDTO
    {
        public Guid Id { get; set; }
        public string Position { get; set; }
        public int Count { get; set; }
    }
}
