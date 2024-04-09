using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.RFIFeature.Command;

public class SendMessageToRFIChatCommandHandler : IRequestHandler<SendMessageToRFIChatCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public SendMessageToRFIChatCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(SendMessageToRFIChatCommand command, CancellationToken cancellationToken)
    {
        var message = new ChatMessage
        {
            RFIChatId = command.RFIChatId,
            MessageType = command.MessageType,
            Content = command.Content,
            SentByUserId = command.SentByUserId,
            Timestamp = DateTime.UtcNow
        };

        _dbContext.ChatMessages.Add(message);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return message.Id;
    }
}

