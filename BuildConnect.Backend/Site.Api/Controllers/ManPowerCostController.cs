using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.ManPowerCostFeature.Command;
using Site.Application.Features.ManPowerCostFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManPowerCostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManPowerCostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ManPowerCost
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ManPowerCostDTO>>> GetByWorkItem(Guid workItemId)
        {
            var query = new GetManPowerCostsByWorkItemQuery { WorkItem = workItemId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST: api/ManPowerCost
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateManPowerCostCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT: api/ManPowerCost/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, UpdateManPowerCostCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE: api/ManPowerCost/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteManPowerCostCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }

}
