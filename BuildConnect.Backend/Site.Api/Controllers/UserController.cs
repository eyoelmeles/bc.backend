using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.AssignSiteUserFeature.Query;
using Site.Application.Features.UserFeature.Command;
using Site.Application.Features.UserFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;


    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]

    public async Task<ActionResult<UserDTO>> Get([FromQuery] Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
        return Ok(user);
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }
    [HttpGet("Roles")]
    public async Task<ActionResult<IEnumerable<string>>> GetRoles()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());
        return Ok(roles);
    }
    [HttpGet("bysite")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetBySite(Guid siteId)
    {
        var users = await _mediator.Send(new GetUsersBySiteQuery { SiteId = siteId });
        return Ok(users);
    }

    //[HttpGet("byrole")]
    //public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByRole(Rolez roleType)
    //{
    //    var users = await _mediator.Send(new GetAllUsersByRolesQuery { role = roleType });
    //    return Ok(users);
    //}

    //[HttpPost]
    //public async Task<ActionResult<Guid>> Create([FromForm] RegisterUserCommand command)
    //{
    //    var userId = await _mediator.Send(command); 
    //    return Ok(userId);
    //}


    [HttpPut()]
    public async Task<IActionResult> Update(UpdateUserCommand command)
    {
        var user = await _mediator.Send(command);
        return Ok(user);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(Rolez.Admin) + "," + nameof(Rolez.DataCollector))]

    public async Task<Unit> Delete([FromQuery] Guid id)
    {
        await _mediator.Send(new DeleteUserCommand {
            Id = id
        });
        return Unit.Value;
    }
    
}
