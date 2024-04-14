using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.RoleFeatures.Command;
using Site.Application.Features.RoleFeatures.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMediator _mediator;

        public RoleController(ILogger<RoleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<RoleDto>> Get([FromQuery] Guid id)
        {
            var role = await _mediator.Send(new GetRoleQuery { Id = id });
            return Ok(role);
        }
        [HttpGet("all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var roles = await _mediator.Send(new GetAllRolesQuery());
            return Ok(roles);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateRoleCommand command)
        {
            var roleId = await _mediator.Send(command);
            return Ok(roleId);
        }
    }
}
