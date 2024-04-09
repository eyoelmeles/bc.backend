using AutoMapper;
using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.StaffOnSiteFeature.Command;

public class CreateStaffOnSiteCommandCommandHandler : IRequestHandler<CreateStaffOnSiteCommand, Guid>
{

    private readonly IApplicationDbContext _context;

    public CreateStaffOnSiteCommandCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateStaffOnSiteCommand request, CancellationToken cancellationToken)
    {
        var staffOnSite = new StaffOnSite
        {
            Position = request.Position,
            Count = request.Count
        };
        _context.StaffOnSites.Add(staffOnSite);
        await _context.SaveChangesAsync(cancellationToken);
        return staffOnSite.Id;
    }
}

