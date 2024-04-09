using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Common.Interface;

public interface IJwtService
{
    string GenerateToken(User user);
    ClaimsPrincipal ValidateToken(string token);
}
