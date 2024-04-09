using MediatR;
using Microsoft.AspNetCore.Http;
using Site.Domain.Entity;

namespace Site.Application.Features.SiteFeatures.Command;
public class CreateSiteCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Owner { get; set; }
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public string Supervisor { get; set; }
    public string Contractor { get; set; }
    public string Client { get; set; }

    public IFormFile? Logo { get; set; }
}
public class UpdateSiteCommand : IRequest<SiteDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
    public long Longitude { get; set; }
    public long Latitude { get; set; }
    public IFormFile Logo { get; set; }
}
public class DeleteSiteCommand : IRequest
{
    public Guid Id { get; set; }
}