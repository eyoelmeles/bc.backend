// using Site.Application.Common.Interface;

// namespace Site.Api.Middleware;

// public class RoleValidationMiddleware
// {
//     private readonly RequestDelegate _next;
//     private readonly IApplicationDbContext _context;

//     public RoleValidationMiddleware(RequestDelegate next, IApplicationDbContext context)
//     {
//         _next = next;
//         _context = context;
//     }

//     public async Task InvokeAsync(HttpContext httpContext)
//     {
//         if (httpContext.User.Identity.IsAuthenticated)
//         {
//             var roleTimestampClaim = httpContext.User.FindFirst("RoleTimestamp");
//             var userRoleIdClaim = httpContext.User.FindFirst("UserRoleIdClaimType");

//             if (roleTimestampClaim != null && userRoleIdClaim != null)
//             {
//                 DateTime tokenRoleTimestamp;
//                 if (DateTime.TryParse(roleTimestampClaim.Value, out tokenRoleTimestamp))
//                 {
//                     Guid userRoleId;
//                     if (Guid.TryParse(userRoleIdClaim.Value, out userRoleId))
//                     {
//                         var roleInDb = await _context.Roles.FindAsync(userRoleId);

//                         if (roleInDb != null && roleInDb.UpdatedAt > tokenRoleTimestamp)
//                         {
//                             httpContext.Response.StatusCode = 401;
//                             await httpContext.Response.WriteAsync("Role information outdated. Please refresh your token.");
//                             return;
//                         }
//                     }
//                     else
//                     {
//                         httpContext.Response.StatusCode = 400;
//                         await httpContext.Response.WriteAsync("Invalid user role ID in token.");
//                         return;
//                     }
//                 }
//                 else
//                 {
//                     httpContext.Response.StatusCode = 400;
//                     await httpContext.Response.WriteAsync("Invalid role timestamp in token.");
//                     return;
//                 }
//             }
//             else
//             {
//                 httpContext.Response.StatusCode = 400;
//                 await httpContext.Response.WriteAsync("Required claims (role timestamp or user role ID) missing from token.");
//                 return;
//             }
//         }

//         await _next(httpContext);
//     }
// }

