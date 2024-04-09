using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.WorkItemFeature.Command;
using Site.Application.Features.WorkItemFeature.Query;
using Site.Domain.Entity;
using System.Xml.Linq;

namespace Site.Api.Controllers;

[Route("[Controller]")]
[ApiController]
public class WorkItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkItemsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    // POST api/workitems
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateWorkItem(CreateWorkItemCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // PUT api/workitems/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkItem(Guid id, UpdateWorkItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Mismatched WorkItem Ids in URL and body.");
        }

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/workitems/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkItem(Guid id)
    {
        await _mediator.Send(new DeleteWorkItemCommand { Id = id });
        return NoContent();
    }

    // GET api/workitems/schedule/{scheduleId}
    [HttpGet("schedule")]
    public async Task<ActionResult<IEnumerable<WorkItemDTO>>> GetAllBySchedule(Guid scheduleId)
    {
        var query = new GetAllWorkItemsByScheduleQuery { ScheduleId = scheduleId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("site")]
    public async Task<ActionResult<IEnumerable<WorkItemDTO>>> GetAllBySite(Guid siteId)
    {
        var query = new GetAllWorkItemsBySiteQuery { SiteId = siteId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    // This is just an example if you want to provide an endpoint to fetch a single workitem by its Id
    // GET api/workitems/{id}
    //    [HttpGet("{id}", Name = "GetWorkItemById")]
    //    public async Task<ActionResult<WorkItemDto>> GetWorkItemById(Guid id)
    //    {
    //        // Implementation here (not provided in the original question)
    //    }
}
