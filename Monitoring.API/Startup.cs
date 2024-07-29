using Microsoft.AspNetCore.Identity;
using Monitoring.Application;
using Monitoring.Domain.Entities;
using Monitoring.Infrastructure;
using Monitoring.Infrastructure.Persistance;

namespace Monitoring.API
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services, ILoggingBuilder Logging)
        {

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            services.AddMonitoringApplicationDependencyInjection();
            services.AddMonitoringInfrastructureDependencyInjection(configRoot);

            services.AddIdentity<Employee, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<MonitoringDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();

            services.AddControllers().
                AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
