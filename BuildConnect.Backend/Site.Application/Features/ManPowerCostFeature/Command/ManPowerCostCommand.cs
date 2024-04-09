using MediatR;

namespace Site.Application.Features.ManPowerCostFeature.Command;

public class CreateManPowerCostCommand : IRequest<Guid>
{
    public Guid LabourId { get; set; }
    public int Count { get; set; }
    public decimal UnitFactor { get; set; }
    public decimal HourlyIndex { get; set; }
    public Guid WorkItem { get; set; }
}

public class UpdateManPowerCostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid LabourId { get; set; }
    public int Count { get; set; }
    public decimal UnitFactor { get; set; }
    public decimal HourlyIndex { get; set; }
    public Guid WorkItem { get; set; }
}

public class DeleteManPowerCostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
