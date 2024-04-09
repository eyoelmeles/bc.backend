using MediatR;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.ChatFeature.Command;

public class SendVoiceMessageCommandHandler : IRequestHandler<SendVoiceMessageCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileService _fileService;

    public SendVoiceMessageCommandHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<Guid> Handle(SendVoiceMessageCommand request, CancellationToken cancellationToken)
    {
        byte[] voiceBytes = Convert.FromBase64String(request.Base64VoiceData.Split(',')[1]);
        string fileType = "mp3"; // Assuming mp3 format for voice messages
        string voiceFileName = await _fileService.SaveFileAsync(voiceBytes, fileType, "VoiceMessages");

        var message = new Message
        {
            Id = Guid.NewGuid(),
            SenderId = request.SenderId,
            ChatId = request.ChatId,
            Type = MessageType.Voice,
            FileUrl = voiceFileName,
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync(cancellationToken);
        return message.Id;
    }
}

