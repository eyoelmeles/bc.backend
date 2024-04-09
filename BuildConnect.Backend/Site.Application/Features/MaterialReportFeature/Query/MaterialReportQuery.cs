using MediatR;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialReportFeatures.Query;

public class GetMaterialReportQuery : IRequest<MaterialReportDTO>
{
    public Guid Id { get; set; }
}

public class GetMaterialReportByReportIdQuery : IRequest<IEnumerable<MaterialReportDTO>>
{
    public Guid DailyReport { get; set; }
}

public class GetAllMaterialReportsBySiteQuery : IRequest<IEnumerable<MaterialReportDTO>>
{
    public Guid SiteId { get; set; }
}