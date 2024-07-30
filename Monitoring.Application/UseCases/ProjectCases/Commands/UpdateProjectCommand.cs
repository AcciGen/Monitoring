using MediatR;
using Monitoring.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ProjectCases.Commands
{
    public class UpdateProjectCommand : IRequest<ResponseModel>
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
    }
}
