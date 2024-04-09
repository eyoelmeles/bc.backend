using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.FoldersFeature.Command;
using Site.Application.Features.FoldersFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FolderController: ControllerBase
    {
        private readonly IMediator _mediator;

        public FolderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<FolderDto>>> GetAll(Guid siteId)
        {
            var folders = await _mediator.Send(new GetAllFoldersQuery
            {
                SiteId = siteId
            });
            return Ok(folders);
        }

        [HttpPost]
        public async Task<ActionResult<FolderDto>> Create(CreateFolderCommand command)
        {
            var site = await _mediator.Send(command);
            return Ok(site);
        }
    }
}
