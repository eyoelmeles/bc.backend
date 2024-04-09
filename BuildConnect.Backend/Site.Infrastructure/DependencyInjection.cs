using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Site.Application.Common.Interface;
using Site.Infrastructure.Service;
using System.Reflection;

namespace Site.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IFileService, FileService>();
            return services;
        }
    }

}
