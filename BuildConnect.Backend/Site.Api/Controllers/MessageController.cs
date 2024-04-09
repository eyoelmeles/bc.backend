using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.ChatFeature.Command;
using Site.Application.Features.ChatFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("sendText")]
        public async Task<ActionResult<Guid>> SendTextMessage(SendTextMessageCommand command)
        {
            var messageId = await _mediator.Send(command);
            return Ok(messageId);
        }

        [HttpPost("sendVoice")]
        public async Task<ActionResult<Guid>> SendVoiceMessage(SendVoiceMessageCommand command)
        {
            var messageId = await _mediator.Send(command);
            return Ok(messageId);
        }

        [HttpGet("{chatId}")]
        public async Task<ActionResult<List<Message>>> GetMessagesForChat(Guid chatId)
        {
            var messages = await _mediator.Send(new GetMessagesForChatQuery { ChatId = chatId });
            return Ok(messages);
        }
        [HttpPut("editMessage")]
        public async Task<IActionResult> EditMessage(EditMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("deleteMessage/{messageId}")]
        public async Task<IActionResult> DeleteMessage(Guid messageId)
        {
            var result = await _mediator.Send(new DeleteMessageCommand { MessageId = messageId });
            return result ? Ok() : NotFound();
        }
    }
}
