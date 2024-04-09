using MediatR;
using Site.Application.Common.Interface;

namespace Site.Application.Features.UserFeature.Command;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}