using MediatR;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.DailyReportFeature.Query;

public class GetDailyReportQuery : IRequest<DailyReport>
{
    public Guid ReportId { get; set; }
}
