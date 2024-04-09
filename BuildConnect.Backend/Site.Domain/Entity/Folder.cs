using Site.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Domain.Entity
{
    public class Folder : BaseModel
    {
        public string Name { get; set; }
        [ForeignKey(nameof(SiteModel))]
        public Guid SiteId { get; set; }
        public virtual SiteModel Site { get; set; }
    }

    public class FolderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SiteId { get; set; }
    }
}
