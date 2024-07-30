using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProjectName { get; set; }
        public double Amount { get; set; }
        public double BudgetTarget { get; set; }
        public double? Received { get; set; }
        public DateOnly StartingDate { get; set; }
        public DateOnly EndingDate { get; set; }
        public List<double>? EmployeePercent { get; set; }
        public virtual List<Employee>? Employees { get; set; }
        public virtual List<Password>? Passwords { get; set; }
    }
}
