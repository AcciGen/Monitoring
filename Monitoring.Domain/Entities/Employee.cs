using Microsoft.AspNetCore.Identity;

namespace Monitoring.Domain.Entities
{
    public class Employee : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public double? Salary { get; set; }
        public double? GivenSalary { get; set; }
        public DateTimeOffset? SalaryDate { get; set; }
        public DateTimeOffset EmploymentDate { get; set; }
        public short? Percent { get; set; }

        public double? Fine { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? FineDate { get; set; }
        public double? RemainedSalary { get; set; }

        public virtual List<Project> Projects { get; set; }
    }
}
