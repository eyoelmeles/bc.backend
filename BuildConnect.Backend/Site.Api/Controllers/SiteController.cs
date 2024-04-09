using Microsoft.AspNetCore.Mvc;
using MediatR;
using Site.Application.Features.SiteFeatures.Command;
using Site.Application.Features.SiteFeatures.Query;
using Site.Domain.Entity;
using Site.Application.Features.AssignSiteUserFeature.Command;
using Site.Application.Features.AssignSiteUserFeature.Query;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteController : ControllerBase
    {
        

        private readonly IMediator _mediator;

        public SiteController( IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<SiteDTO>> Get([FromQuery] Guid id)
        {
            var site = await _mediator.Send(new GetSiteQuery { Id = id });
            return Ok(site);
        }
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<SiteDTO>>> GetAll()
        {
            var sites = await _mediator.Send(new GetAllSitesQuery());
            return Ok(sites);
        }
        [HttpGet("byuser")]
        public async Task<ActionResult<IEnumerable<SiteDTO>>> GetUSiteByUser([FromQuery] Guid userId)
        {
            var users = await _mediator.Send(new GetSiteByUserQuery { UserId = userId });
            return Ok(users);
        }
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers([FromQuery] Guid id)
        {
            var users = await _mediator.Send(new GetUsersBySiteQuery { SiteId = id });
            return Ok(users);
        }

        [HttpGet("sites")]
        public async Task<ActionResult<IEnumerable<SiteDTO>>> GetSites([FromQuery] Guid id)
        {
            var sites = await _mediator.Send(new GetSitesByUserId { UserId = id});
            return Ok(sites);
        }

        [HttpPost]
        public async Task<ActionResult<SiteDTO>> Create([FromForm] CreateSiteCommand command)
        {
            var site = await _mediator.Send(command);
            return Ok(site);
        }
        [HttpPost("AssignUser")]
        public async Task<ActionResult<SiteUserDTO>> AssignUser(CreateSiteUserCommand command)
        {
            var site = await _mediator.Send(command);
            return Ok(site);
        }
        [HttpPut]
        public async Task<ActionResult<SiteDTO>> Update(UpdateSiteCommand command)
        {
            var site = await _mediator.Send(command);
            return Ok(site);
        }
        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete([FromQuery] Guid id)
        {
            var siteId = await _mediator.Send(new DeleteSiteCommand { Id = id});
            return Ok(siteId);
        }
    }
}