
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using XNerd.Ecommerce.Application.Models.Token;
using XNerd.Ecommerce.Application.Persistence;
using XNerd.Ecommerce.Infrastructure.Repositories;

namespace XNerd.Ecommerce.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices( this IServiceCollection services, IConfiguration configuration )
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped( typeof(IRepository<>), typeof(RepositoryBase<>) );

            services.Configure<JwtSettings>( configuration.GetSection("JwtSettings") );

            return services;
        }
    }
}