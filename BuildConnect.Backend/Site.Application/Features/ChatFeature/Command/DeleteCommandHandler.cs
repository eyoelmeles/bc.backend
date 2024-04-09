using MediatR;
using Site.Application.Common.Interface;

namespace Site.Application.Features.ChatFeature.Command;

public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteChatCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
    {
        var chat = await _context.Chats.FindAsync(request.ChatId);
        if (chat == null) return false;

        _context.Chats.Remove(chat);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

