using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.ConsumptionCases.Queries;
using Monitoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ConsumptionCases.Handlers.QueryHandlers
{
    public class GetAllConsumptionQueryHandler : IRequestHandler<GetAllConsumptionQuery, IEnumerable<Consumption>>
    {
        private readonly IMonitoringDbContext _context;

        public GetAllConsumptionQueryHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consumption>> Handle(GetAllConsumptionQuery request, CancellationToken cancellationToken)
        {
            return await _context.Consumptions.ToListAsync(cancellationToken);
        }
    }
}
