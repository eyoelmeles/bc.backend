using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ChatFeature.Command;

public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateChatCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var chat = new Chat
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            SiteId = request.SiteId
        };

        _context.Chats.Add(chat);
        foreach (var userId in request.ParticipantUserIds)
        {
            _context.UserChats.Add(new UserChat { UserId = userId, ChatId = chat.Id });
        }

        await _context.SaveChangesAsync(cancellationToken);
        return chat.Id;
    }
}

