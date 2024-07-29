using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Domain.Entities
{
    public class Password
    {
        public Guid Id { get; set; }
        public string Program { get; set; }
        public string Login { get; set; }
        public string? Pass { get; set; }
        public Guid ProjectId { get; set; }
        public virtual Project FutureProject { get; set; }
    }
}
