using MediatR;
using Microsoft.AspNetCore.Http;

namespace Site.Application.Features.EquipmentReportFeature.Command;

public class CreateEquipmentReportCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public int WorkHour { get; set; }
    public int EdleHour { get; set; }
    public IFormFile? Image { get; set; }
}
