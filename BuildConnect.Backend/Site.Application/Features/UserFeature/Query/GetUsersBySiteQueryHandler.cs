using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.UserFeature.Query;

public class GetUserBySiteIdQueryHandler : IRequestHandler<GetUserBySiteIdQuery, IEnumerable<UserDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetUserBySiteIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> Handle(GetUserBySiteIdQuery request, CancellationToken cancellationToken)
    {
        var siteUsers = await _context.SiteUsers
            .Include(su => su.User)
            .Where(su => su.SiteId == request.SiteId)
            .ToListAsync(cancellationToken);

        if (siteUsers == null)
        {
            return null;
        }

        
        var userDTO = _mapper.Map<IEnumerable<UserDTO>>(siteUsers);

        return userDTO;
    }
}