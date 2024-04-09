using MediatR;

namespace Site.Application.Features.MaterialCostFeature.Command;

public class CreateMaterialCostCommand : IRequest<Guid>
{
    public Guid MaterialId { get; set; }
    public Guid UnitOfMeasureId { get; set; }
    public int Quantity { get; set; }
    public decimal Rate { get; set; }
    public decimal CostPerUnit { get; set; }
    public Guid WorkItemId { get; set; }
}

public class UpdateMaterialCostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid MaterialId { get; set; }
    public Guid UnitOfMeasureId { get; set; }
    public int Quantity { get; set; }
    public decimal Rate { get; set; }
    public decimal CostPerUnit { get; set; }
    public Guid WorkItemId { get; set; }
}

public class DeleteMaterialCostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
