using MediatR;
using Monitoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ConsumptionCases.Queries
{
    public class GetAllConsumptionQuery : IRequest<IEnumerable<Consumption>>
    {
    }
}
