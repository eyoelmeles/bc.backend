using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.ScheduleFeature.Command;
using Site.Application.Features.ScheduleFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public ScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetRoot()
    {
        var rootSchedules = await _mediator.Send(new GetRootSchedules());
        return Ok(rootSchedules);
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetAll(Guid siteId)
    {
        var schedules = await _mediator.Send(new GetAllSchedules { SiteId = siteId});
        return Ok(schedules);
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateSchedlueCommand command)
    {
        var scheduleId = await _mediator.Send(command);
        return Ok(scheduleId);
    }
    [HttpDelete]
    public async Task<ActionResult<Unit>> Delete(Guid id)
    {
        var deleteSchedule = await _mediator.Send(new DeleteScheduleCommand { Id = id });
        return Ok(deleteSchedule);
    }
    [HttpGet("child")]
    public async Task<ActionResult<IEnumerable<ScheduleDTO>>> GetChildSchedules(Guid id)
    {
        var schedules = await _mediator.Send(new GetChildSchedules { Id = id });
        return Ok(schedules);
    }
}
