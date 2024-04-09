using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System.Text.RegularExpressions;


namespace Site.Application.Features.UserFeature.Command;
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public RegisterUserCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }
    public string GetFileTypeFromBase64(string base64DataUrl)
    {
        var match = Regex.Match(base64DataUrl, @"^data:image\/([a-zA-Z0-9]+);base64,");
        if (match.Success && match.Groups.Count > 1)
        {
            return match.Groups[1].Value;
        }
        return null;
    }
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        byte[] fileBytes;

        using (var memoryStream = new MemoryStream())
        {
            await request.ProfileImage.CopyToAsync(memoryStream);
            fileBytes = memoryStream.ToArray();
        }

        // Detect file type using ImageSharp
        var format = Image.DetectFormat(fileBytes);

        // Check if the detected format is valid
        if (format == null)
        {
            throw new Exception("Invalid image format.");
        }


        var fileExtension = format.FileExtensions.FirstOrDefault();

        var fileName = await _fileService.SaveFileAsync(fileBytes, fileExtension, "UserProfileImages");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);


        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            UserName = request.UserName,
            PasswordHash = passwordHash,
            ProfileImage = fileName,
            Role = request.Role
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}