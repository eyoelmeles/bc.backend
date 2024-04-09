namespace Site.Application.Features.RFIFeature.Command;

using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateRFICommandHandler : IRequestHandler<CreateRFICommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateRFICommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateRFICommand request, CancellationToken cancellationToken)
    {
        var fileDetail = new FileDetail
        {
            FileId = request.FileId,
            Details = $"{request.Title} - RFI Attachment",
            FileType = FileDetailType.rfi,
            X = request.X,
            Y = request.Y
        };

        await _context.FileDetails.AddAsync(fileDetail, cancellationToken);

        var rfi = new RFI
        {
            Title = request.Title,
            Description = request.Description,
            Status = RFIStatus.pending,
            Date = DateTime.UtcNow,
            SiteId = request.SiteId,
            Assignee = request.Assignee,
            Attachement = fileDetail.Id
        };

        await _context.RFIs.AddAsync(rfi, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return rfi.Id;
    }
}

