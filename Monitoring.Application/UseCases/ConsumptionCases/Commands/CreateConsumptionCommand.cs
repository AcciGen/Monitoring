using MediatR;
using Monitoring.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ConsumptionCases.Commands
{
    public class CreateConsumptionCommand : IRequest<ResponseModel>
    {
        public string WhyNeeded { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
