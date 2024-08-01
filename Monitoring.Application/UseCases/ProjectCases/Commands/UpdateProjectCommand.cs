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
        public string StartingDate { get; set; }
        public string EndingDate { get; set; }
    }
}
