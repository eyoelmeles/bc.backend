using Site.Domain.Entity;

namespace Site.Application.Features.UserFeature.Common
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }

    }
}
