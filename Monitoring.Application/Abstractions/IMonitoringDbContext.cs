using Microsoft.EntityFrameworkCore;
using Monitoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.Abstractions
{
    public interface IMonitoringDbContext
    {
        DbSet<Consumption> Consumptions { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Password> Passwords { get; set; }
        DbSet<Project> Projects { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
