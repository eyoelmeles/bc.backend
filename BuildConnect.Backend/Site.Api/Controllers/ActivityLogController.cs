using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.ActivityLogFeature.Command;
using Site.Application.Features.ActivityLogFeature.Query;
using Site.Domain.Common;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityLogController : ControllerBase
{
    private readonly ILogger<AssignRoleController> _logger;
    private readonly IMediator _mediator;

    public ActivityLogController(ILogger<AssignRoleController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateActivityLog(CreateActivityLogCommand command)
    {
        var activityId = await _mediator.Send(command);
        return Ok(activityId);
    }
    [HttpGet()]
    public async Task<ActionResult<PaginatedResult<ActivityLog>>> GetUserActivities([FromQuery] GetUserActivitiesQuery query)
    {
        var chats = await _mediator.Send(query);
        return Ok(chats);
    }
}
