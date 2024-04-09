using MediatR;
using Site.Application.Common.Interface;


namespace Site.Application.Features.ChatFeature.Command;

public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteMessageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await _context.Messages.FindAsync(request.MessageId);
        if (message == null) return false;

        _context.Messages.Remove(message);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

