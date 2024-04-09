using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.MaterialReportFeatures.Command;

public class CreateMaterialReportCommandCommandHandler : IRequestHandler<CreateMaterialReportCommand, Guid>
{

    private readonly IApplicationDbContext _context;

    public CreateMaterialReportCommandCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateMaterialReportCommand request, CancellationToken cancellationToken)
    {
        var material = new MaterialReport
        {
            Name = request.Name,
            Quantity = request.Quantity
        };
        _context.MaterialReports.Add(material);
        await _context.SaveChangesAsync(cancellationToken);
        return material.Id;
    }
}
