using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.MaterialCostFeature.Command;
using Site.Application.Features.MaterialCostFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialCostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaterialCostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/MaterialCost
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MaterialCostDTO>>> GetByWorkItem(Guid workItemId)
        {
            var query = new GetMaterialCostsByWorkItemQuery { WorkItem = workItemId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST: api/MaterialCost
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateMaterialCostCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT: api/MaterialCost/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, UpdateMaterialCostCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE: api/MaterialCost/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteMaterialCostCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }

}
