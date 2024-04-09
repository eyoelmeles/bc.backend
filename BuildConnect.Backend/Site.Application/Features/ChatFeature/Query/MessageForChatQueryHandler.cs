using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.ChatFeature.Query;

public class GetMessagesForChatQueryHandler : IRequestHandler<GetMessagesForChatQuery, List<Message>>
{
    private readonly IApplicationDbContext _context;

    public GetMessagesForChatQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Message>> Handle(GetMessagesForChatQuery request, CancellationToken cancellationToken)
    {
        return await _context.Messages
                             .Where(m => m.ChatId == request.ChatId)
                             .OrderBy(m => m.CreatedAt)
                             .ToListAsync(cancellationToken);
    }
}
