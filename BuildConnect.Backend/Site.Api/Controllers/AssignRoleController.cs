using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.RoleFeatures.Command;


namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignRoleController : ControllerBase
    {
        private readonly ILogger<AssignRoleController> _logger;
        private readonly IMediator _mediator;

        public AssignRoleController(ILogger<AssignRoleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
    }
}
