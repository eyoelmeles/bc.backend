using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.ChatFeature.Command;
using Site.Application.Features.ChatFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateChat(CreateChatCommand command)
        {
            var chatId = await _mediator.Send(command);
            return Ok(chatId);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ChatDto>>> GetChatsForUser(Guid userId, Guid siteId)
        {
            var chats = await _mediator.Send(new GetChatsForUserQuery { UserId = userId, SiteId = siteId});
            return Ok(chats);
        }
        [HttpPut("editChat")]
        public async Task<IActionResult> EditChat(EditChatCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("deleteChat/{chatId}")]
        public async Task<IActionResult> DeleteChat(Guid chatId)
        {
            var result = await _mediator.Send(new DeleteChatCommand { ChatId = chatId });
            return result ? Ok() : NotFound();
        }

    }
}
