using MediatR;
using Site.Application.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.ChatFeature.Command;

public class EditChatCommandHandler : IRequestHandler<EditChatCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public EditChatCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(EditChatCommand request, CancellationToken cancellationToken)
    {
        var chat = await _context.Chats.FindAsync(request.ChatId);
        if (chat == null) return false;

        chat.Name = request.NewName;
        // Update other fields if needed.

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
