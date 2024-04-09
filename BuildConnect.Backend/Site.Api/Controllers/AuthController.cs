using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.UserFeature.Command;
using Site.Application.Features.UserFeature.Common;
namespace Site.Api.Controllers;
[ApiController]
[Route("[controller]")]
//[Authorize(Roles = nameof(Rolez.Admin) + "," + nameof(Rolez.DataCollector))]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;


    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("Register")]

    public async Task<ActionResult<Guid>> Register([FromForm] RegisterUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }
    [HttpPost("Login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginUserCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(token);
    }
}