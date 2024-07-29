using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Infrastructure.Persistance
{
    public class MonitoringDbContext : IdentityDbContext<Employee, IdentityRole<Guid>, Guid>, IMonitoringDbContext
    {
        public MonitoringDbContext(DbContextOptions<MonitoringDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
