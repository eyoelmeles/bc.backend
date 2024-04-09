using MediatR;
using Microsoft.AspNetCore.Http;
using Site.Domain.Entity;

namespace Site.Application.Features.InspectionFeature.Command;

public class CreateInspectionCommand : IRequest<Guid>
{
    public string Description { get; set; }
    public Guid ScheduleId { get; set; }
    public Guid AssignedUserId { get; set; }
    public Guid CreatedById { get; set; }
}

public class UpdateInspectionCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public InspectionStatus? Status { get; set; }
}

public class DeleteInspectionCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}

public class InspectTaskCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public bool Status { get; set; }
    public IFormFile? Attachment { get; set; }
}

public class UpdateInspectTaskCommand : IRequest<Unit>
{
    public List<InspectTaskUpdateItem> Updates { get; set; }
}

public class InspectTaskUpdateItem
{
    public Guid Id { get; set; }
    public bool Status { get; set; }
    public IFormFile? Attachment { get; set; }
}