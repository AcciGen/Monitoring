using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Domain.Entities
{
    public class Consumption
    {
        public Guid Id { get; set; }
        public string WhyNeeded { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
    }
}
