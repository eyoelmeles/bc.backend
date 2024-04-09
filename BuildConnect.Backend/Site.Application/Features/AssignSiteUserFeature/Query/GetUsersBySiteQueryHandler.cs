using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.AssignSiteUserFeature.Query
{
    public class GetUsersBySiteQueryHandler : IRequestHandler<GetUsersBySiteQuery, IEnumerable<UserDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetUsersBySiteQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetUsersBySiteQuery request, CancellationToken cancellationToken)
        {
            return await _context.SiteUsers
                .Where(su => su.SiteId == request.SiteId)
                .Join(_context.Users, su => su.UserId, u => u.Id, (su, u) => u)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = u.FullName,
                    PhoneNumber = u.PhoneNumber,
                    ProfileImage = u.ProfileImage,
                    Role = u.Role,
                    UserName = u.UserName
                    // ... other properties
                })
                .ToListAsync(cancellationToken);
        }   
    }
}
