using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.RFIFeature.Command;

public class StartRFIChatCommandHandler : IRequestHandler<StartRFIChatCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public StartRFIChatCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(StartRFIChatCommand command, CancellationToken cancellationToken)
    {
        var chat = new RFIChat
        {
            FileDetailId = command.FileDetailId,
            StartedByUserId = command.StartedByUserId,
            Messages = new List<ChatMessage>
            {
                new ChatMessage
                {
                    MessageType = command.InitialMessageType,
                    Content = command.InitialMessageContent,
                    SentByUserId = command.StartedByUserId,
                    Timestamp = DateTime.UtcNow
                }
            }
        };

        _dbContext.RFIChats.Add(chat);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return chat.Id;
    }
}
