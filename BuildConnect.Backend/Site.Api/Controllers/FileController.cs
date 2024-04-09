using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Application.Features.FileFeature.Command;
using Site.Application.Features.FileFeature.Query;
using Site.Domain.Entity;

namespace Site.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<FileModelDTO>> Get([FromQuery] Guid id)
        {
            var file = await _mediator.Send(new GetFileQuery
            {
                Id = id
            });
            return Ok(file);
        }
        [HttpGet("folder")]
        public async Task<ActionResult<IEnumerable<FileModelDTO>>> GetByFolder(Guid folderId)
        {
            var files = await _mediator.Send(new GetFileByFolderIdQuery { FolderId = folderId });
            return Ok(files);
        }
        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<FileDetailDTO>>> GetDetailsByFileId(Guid fileId)
        {
            var fileDetails = await _mediator.Send(new GetFileDetailByFileIdQuery(fileId: fileId));
            return Ok(fileDetails);
        }
        [HttpGet("detail")]
        public async Task<ActionResult<FileDetailDTO>> GetFileDetail(Guid fileDetailId)
        {
            var fileDetail = await _mediator.Send(new GetFileDetailQuery { 
                Id = fileDetailId
            });
            return Ok(fileDetail);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateFileCommand command)
        {
            var fileId = await _mediator.Send(command);
            return Ok(fileId);
        }
    }
}
