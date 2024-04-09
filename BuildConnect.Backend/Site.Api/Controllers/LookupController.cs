using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.LookupFeature.Command;
using Site.Application.Features.LookupFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LookupController: ControllerBase
{
    private readonly IMediator _mediator;

    public LookupController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<LookupDTO>>> Get(Guid siteId)
    {
        var lookups = await _mediator.Send(new GetLookupsBySite { SiteId = siteId });
        return Ok(lookups);
    }
    [HttpGet("bytype")]
    public async Task<ActionResult<IEnumerable<LookupDTO>>> GetByType(LookupType lookupType, Guid siteId)
    {
        var lookups = await _mediator.Send(new GetLookupByLookupType { LookupType = lookupType, SiteId = siteId});
        return Ok(lookups);
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateLookupCommand command)
    {
        var lookupId = await _mediator.Send(command);
        return Ok(lookupId);
    }
    [HttpDelete]
    public async Task<ActionResult<Unit>> DeleteLookup(Guid id)
    {
        var deleteLookup = await _mediator.Send(new DeleteLookupCommand { Id = id });
        return Ok(deleteLookup);
    }
    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<string>>> GetLookupTypes()
    {
        var lookupTypes = await _mediator.Send(new GetLookupTypes());
        return Ok(lookupTypes);
    }
}
