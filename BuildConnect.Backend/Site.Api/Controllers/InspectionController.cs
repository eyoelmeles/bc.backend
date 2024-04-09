using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.InspectionFeature.Command;
using Site.Application.Features.InspectionFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InspectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public InspectionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<InspectionDTO>>> GetAll(Guid siteId)
    {
        var inspections = await _mediator.Send(new GetInspections { SiteId = siteId });
        return Ok(inspections);
    }
    [HttpGet("status")]
    public async Task<ActionResult<IEnumerable<InspectionDTO>>> GetByStatus(InspectionStatus status)
    {
        var inspections = await _mediator.Send(new GetInspectionByStatus { Status = status});
        return Ok(inspections);
    }
    [HttpGet("schedule")]
    public async Task<ActionResult<IEnumerable<InspectionDTO>>> GetBySchedule(Guid scheduleId)
    {
        var inspections = await _mediator.Send(new GetInspectionBySchedule { ScheduleId = scheduleId });
        return Ok(inspections);
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateInspectionCommand command)
    {
        var inspectionId = await _mediator.Send(command);
        return Ok(inspectionId);
    }
    [HttpDelete]
    public async Task<ActionResult<Unit>> Delete(Guid id)
    {
        var deleteInspection = await _mediator.Send(new DeleteInspectionCommand { Id = id });
        return Ok(deleteInspection);
    }
    [HttpPut()]
    public async Task<ActionResult<IEnumerable<ScheduleDTO>>> UpdateInspection(UpdateInspectionCommand command)
    {
        var inspectionId = await _mediator.Send(command);
        return Ok(inspectionId);
    }
}
