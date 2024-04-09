using MediatR;
using Site.Application.Common.Interface;

namespace Site.Application.Features.ChatFeature.Command;

public class EditMessageCommandHandler : IRequestHandler<EditMessageCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public EditMessageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(EditMessageCommand request, CancellationToken cancellationToken)
    {
        var message = await _context.Messages.FindAsync(request.MessageId);
        if (message == null) return false;

        message.Content = request.NewContent;
        // Update other fields if needed.

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
