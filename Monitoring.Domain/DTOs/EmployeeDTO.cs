using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Domain.DTOs
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public double? Salary { get; set; }
        public double? GivenSalary { get; set; }
        public string? SalaryDate { get; set; }
        public string EmploymentDate { get; set; }
        public short? Percent { get; set; }

        public double? Fine { get; set; }
        public string? Description { get; set; }
        public string? FineDate { get; set; }
        public double? RemainedSalary { get; set; }
    }
}
