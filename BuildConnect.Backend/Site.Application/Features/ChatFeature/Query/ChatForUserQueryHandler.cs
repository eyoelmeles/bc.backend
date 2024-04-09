using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.ChatFeature.Query;

public class GetChatsForUserQueryHandler : IRequestHandler<GetChatsForUserQuery, List<ChatDto>>
{
    private readonly IApplicationDbContext _context;

    public GetChatsForUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ChatDto>> Handle(GetChatsForUserQuery request, CancellationToken cancellationToken)
    {
        var chats = await _context.Chats
           .Include(c => c.UserChats)
           .Include(c => c.Messages) // Include messages if you want them in the DTO
           .Where(c => c.SiteId == request.SiteId && c.UserChats.Any(uc => uc.UserId == request.UserId))
           .ToListAsync(cancellationToken);

        var chatDtos = chats.Select(c => new ChatDto
        {
            Id = c.Id,
            Name = c.Name,
            Type = c.Type,
            UserChats = c.UserChats, // Directly assigning might be okay if UserChat doesn't need any transformation
            Messages = c.Messages,   // Directly assigning might be okay if Message doesn't need any transformation
            SiteId = c.SiteId
        }).ToList();

        return chatDtos;
    }
}