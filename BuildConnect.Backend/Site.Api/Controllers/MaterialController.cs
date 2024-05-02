using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.MaterialFeature.Command;
using Site.Application.Features.MaterialFeatures.Query;
// using Site.Application.Features.RoleFeatures.Query;
using Site.Application.Features.UserFeature.Command;
using Site.Domain.Entity;

namespace Site.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MaterialController : ControllerBase
{
    private readonly IMediator _mediator;


    public MaterialController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<MaterialDTO>> Get([FromQuery] Guid id)
    {
        var material = await _mediator.Send(new GetMaterialQuery { Id = id });
        return Ok(material);
    }
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAll()
    {
        var materials = await _mediator.Send(new GetAllMaterialsQuery());
        return Ok(materials);
    }
    [HttpPost]
    public async Task<ActionResult<MaterialDTO>> Create(CreateMaterialCommand command)
    {
        var material = await _mediator.Send(command);
        return Ok(material);
    }
    [HttpPut]
    public async Task<ActionResult<MaterialDTO>> Update(UpdateMaterialCommand command)
    {
        var material = await _mediator.Send(command);
        return Ok(material);
    }
    [HttpDelete]
    public async Task<ActionResult<Unit>> Delete(DeleteMaterialCommand command)
    {
        var material = await _mediator.Send(command);
        return Ok(material);
    }
}