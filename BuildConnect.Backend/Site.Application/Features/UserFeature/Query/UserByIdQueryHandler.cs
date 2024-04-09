using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.UserFeature.Query;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public GetUserByIdQueryHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

        if (user == null)
        {
            throw new Exception("User not found."); // You can handle this better with custom exception types and middleware.
        }

        return new UserDTO
        {
            Id = request.Id,
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            UserName = user.UserName,
            Role = user.Role,
            ProfileImage = _fileService.GetFileUrl(user.ProfileImage, "UserProfileImages") // assuming you have such a method in your file service
        };
    }
}