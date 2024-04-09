using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.DailyReportFeature.Query;

public class GetDailyReportQueryHandler : IRequestHandler<GetDailyReportQuery, DailyReport>
{
    private readonly IApplicationDbContext _context;

    public GetDailyReportQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DailyReport> Handle(GetDailyReportQuery request, CancellationToken cancellationToken)
    {
        var report = await _context.DailyReports
                                   .Include(r => r.CreatedBy)
                                   .Include(r => r.ApprovedBy)
                                   .FirstOrDefaultAsync(r => r.Id == request.ReportId, cancellationToken);

        if (report == null)
        {
            throw new NotFoundException("Daily Report not found.");
        }

        return report;
    }
}

