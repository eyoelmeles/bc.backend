using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;


namespace Site.Application.Features.UserFeature.Query;
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public GetAllUsersQueryHandler(IApplicationDbContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<IEnumerable<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.ToListAsync(cancellationToken);
        if (users == null)
        {
            throw new NotFoundException(nameof(User), "*");
        }
        var userDtos = _mapper.Map<IEnumerable<UserDTO>>(users);

        foreach (var userDto in userDtos)
        {
            if (!string.IsNullOrEmpty(userDto.ProfileImage))
            {
                userDto.ProfileImage = _fileService.GetFileUrl(userDto.ProfileImage, "UserProfileImages");
            }
        }

        return userDtos;
    }

    
}