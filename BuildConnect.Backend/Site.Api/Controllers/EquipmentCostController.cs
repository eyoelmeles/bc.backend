using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.EquipmentCostFeature.Command;
using Site.Application.Features.EquipmentCostFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentCostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EquipmentCostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/EquipmentCost
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<EquipmentCostDTO>>> GetByWorkItem(Guid workItemId)
        {
            var query = new GetEquipmentCostsByWorkItemQuery { WorkItem = workItemId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST: api/EquipmentCost
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateEquipmentCostCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT: api/EquipmentCost/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, UpdateEquipmentCostCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE: api/EquipmentCost/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteEquipmentCostCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }

}
