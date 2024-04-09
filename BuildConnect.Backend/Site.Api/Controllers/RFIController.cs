using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.RFIFeature.Command;
using Site.Application.Features.RFIFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RFIController: ControllerBase
{
    private readonly IMediator _mediator;

    public RFIController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("bysite")]
    public async Task<ActionResult<IEnumerable<RFIDTO>>> GetRFIBySite(Guid siteId)
    {
        var rfis = await _mediator.Send(new GetRFIsBySiteQuery { SiteId = siteId });
        return Ok(rfis);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateChat(CreateRFICommand command)
    {
        var rfiId = await _mediator.Send(command);
        return Ok(rfiId);
    }
}
