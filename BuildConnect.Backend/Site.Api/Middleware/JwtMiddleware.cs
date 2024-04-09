using Site.Application.Common.Interface;

namespace Site.Api.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, IJwtService jwtService)
    {
        string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(' ').Last();

        if (token != null)
        {
            try
            {
                jwtService.ValidateToken(token);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }

        await _next(context); // Call the next middleware in the pipeline
    }
}
