using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ChatFeature.Command;

public class SendTextMessageCommandHandler : IRequestHandler<SendTextMessageCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public SendTextMessageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(SendTextMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new Message
        {
            Id = Guid.NewGuid(),
            SenderId = request.SenderId,
            ChatId = request.ChatId,
            Type = MessageType.Text,
            Content = request.Content,
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync(cancellationToken);
        return message.Id;

    }
}