using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monitoring.Application.Abstractions;
using Monitoring.Infrastructure.Persistance;

namespace Monitoring.Infrastructure
{
    public static class MonitoringInfrastructureDI
    {
        public static IServiceCollection AddMonitoringInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IMonitoringDbContext, MonitoringDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            });

            return services;
        }
    }
}
