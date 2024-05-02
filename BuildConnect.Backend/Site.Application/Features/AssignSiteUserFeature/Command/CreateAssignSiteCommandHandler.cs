using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.AssignSiteUserFeature.Command;

public class CreateSiteUserCommandCommandHandler : IRequestHandler<CreateSiteUserCommand, SiteUserDTO>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateSiteUserCommandCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SiteUserDTO> Handle(CreateSiteUserCommand request, CancellationToken cancellationToken)
    {
        var siteExists = await _context.Sites.AnyAsync(s => s.Id == request.SiteId, cancellationToken);
        if (!siteExists)
        {
            throw new InvalidOperationException("SiteId does not exist.");
        }
        var userCount = await _context.Users.CountAsync(u => request.UsersId.Contains(u.Id), cancellationToken);
        if (userCount != request.UsersId.Count)
        {
            throw new InvalidOperationException("One or more UserIds do not exist.");
        }
        var siteUsers = request.UsersId.Select(userId => new SiteUser
        {
            SiteId = request.SiteId,
            UserId = userId,
            Role = request.Role
        });
        await _context.SiteUsers.AddRangeAsync(siteUsers, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var site = await _context.Sites
            .Where(s => s.Id == request.SiteId)
            .Select(s => new SiteDTO
            {
                Id = s.Id,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Name = s.Name,
                Owner = s.Owner
            })
            .FirstOrDefaultAsync(cancellationToken);

        var users = await _context.Users
            .Where(u => request.UsersId.Contains(u.Id))
            .Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                FullName = u.FullName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                ProfileImage = u.ProfileImage,
                Role = u.Role
            })
            .ToListAsync(cancellationToken);

        return new SiteUserDTO
        {
            Site = site,
            Users = users,
            Role = request.Role,
        };
    }
}