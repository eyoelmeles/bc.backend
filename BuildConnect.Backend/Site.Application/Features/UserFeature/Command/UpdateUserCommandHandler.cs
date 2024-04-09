using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.UserFeature.Command;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDTO>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public UpdateUserCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);

        if (request.ProfileImage != null)
        {
            //user.ProfileImage = await _fileService.SaveFileAsync(request.ProfileImage., "jpg", "Content");
        }

        user.FullName = request.FullName ?? user.FullName;
        user.Email = request.Email ?? user.Email;
        user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;
        user.UserName = request.UserName ?? user.UserName;

        await _context.SaveChangesAsync(cancellationToken);

        return new UserDTO
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            UserName = user.UserName,
            Role = user.Role,
            FullName = user.FullName,
            ProfileImage = user.ProfileImage
        };
    }
}
