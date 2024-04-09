using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.RFIFeature.Query;

public class GetRFIChatByFileDetailQueryHandler : IRequestHandler<GetRFIChatByFileDetailQuery, RFIChat>
{
    private readonly IApplicationDbContext _dbContext;

    public GetRFIChatByFileDetailQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RFIChat> Handle(GetRFIChatByFileDetailQuery query, CancellationToken cancellationToken)
    {
        var chat = await _dbContext.RFIChats
            .Include(c => c.Messages)
            .FirstOrDefaultAsync(c => c.FileDetailId == query.FileDetailId);

        return chat;
    }
}

