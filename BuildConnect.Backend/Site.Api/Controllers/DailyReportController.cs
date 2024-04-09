using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.DailyReportFeature.Command;
using Site.Application.Features.DailyReportFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyReportController: ControllerBase
    {
        private readonly IMediator _mediator;

        public DailyReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateDailyReportCommand command)
        {
            var dailyReportId = await _mediator.Send(command);
            return Ok(dailyReportId);
        }
        [HttpGet]
        public async Task<ActionResult<DailyReport>> Get(Guid id)
        {
            var dailyReport = await _mediator.Send(new GetDailyReportQuery { ReportId = id });
            return Ok(dailyReport);
        }
    }
}
