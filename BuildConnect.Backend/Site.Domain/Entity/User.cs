using Site.Domain.Common;

namespace Site.Domain.Entity
{
    public class User : BaseModel
    {
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public string? Signature { get; set; }
    }

    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public Role Role { get; set; }
        public string? Signature { get; set; }
    }

    public enum Role
    {
        Admin,
        SiteEngineer,
        StoreKeeper,
        DataCollector,
        Consultant,
        Contractor,
    }
}
