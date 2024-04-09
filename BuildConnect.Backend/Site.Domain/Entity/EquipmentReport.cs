using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class EquipmentReport : BaseModel
    {
        public string Name { get; set; }
        public int WorkHour { get; set; }
        public int EdleHour { get; set; }
        public string? Image { get; set; }
        public Guid DailyReportId { get; set; }
    }

    public class EquipmentReportDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int WorkHour { get; set; }
        public string? Image { get; set; }
        public int EdleHour { get; set; }
    }
}
