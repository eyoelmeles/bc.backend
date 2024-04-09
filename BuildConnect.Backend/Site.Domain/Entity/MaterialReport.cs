using Site.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entity
{
    public class MaterialReport : BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Guid DailyReportId { get; set; }
        public string? Image { get; set; }
    }

    public class MaterialReportDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }
    }
}
