using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Site.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddMediatR(Assembly.GetExecutingAssembly());
        //services.AddAutoMapper(typeof(Program));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
