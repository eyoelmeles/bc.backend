using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Application.Features.UserFeature.Common;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.UserFeature.Command;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public LoginUserCommandHandler(IApplicationDbContext context, IJwtService jwtService, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _jwtService = jwtService;
        _mapper = mapper;
        _fileService = fileService;
    }
    public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await _context.Users.Where(u => u.UserName == request.UserName).FirstOrDefaultAsync();
        if (foundUser == null)
        {
            throw new NotFoundException(nameof(User), "user not found");
        }
        bool valid = BCrypt.Net.BCrypt.Verify(request.Password, foundUser.PasswordHash);
        if (valid)
        {
            // Manually constructing the UserDto object
            var userDto = new UserDTO
            {
                Id = foundUser.Id,
                FullName = foundUser.FullName,
                UserName = foundUser.UserName,
                PhoneNumber = foundUser.PhoneNumber,
                Email = foundUser.Email,
                ProfileImage = _fileService.GetFileUrl(foundUser.ProfileImage, "UserProfileImages"),
                Role = foundUser.Role,
            };

            // Convert the file location to base64 if it's not empty

            return new LoginResponse
            {
                Token = _jwtService.GenerateToken(foundUser),
                User = userDto
            };
        }
        throw new Exception("Bad Request");
    }
}
