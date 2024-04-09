using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class SiteModel: BaseModel
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Client { get; set; }
        public string Supervisor { get; set; }
        public string Contractor { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string? Logo { get; set; }
    }

    public class SiteDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Client { get; set; }
        public string Supervisor { get; set; }
        public string Contractor { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string? Logo { get; set; }
    }
}
