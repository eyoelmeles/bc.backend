using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class SiteUser : BaseModel
    {
        public Guid SiteId { get; set; }
        public virtual SiteModel Site { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Role Role { get; set; }
    }
    public class SiteUserDTO
    {
        public SiteDTO Site { get; set; }
        public IEnumerable<UserDTO> Users { get; set; }

        public Role Role { get; set; }
    }
}
