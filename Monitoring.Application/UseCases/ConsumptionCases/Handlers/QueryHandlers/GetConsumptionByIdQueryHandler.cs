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
    public class GetConsumptionByIdQueryHandler : IRequestHandler<GetConsumptionByIdQuery, Consumption>
    {
        private readonly IMonitoringDbContext _context;

        public GetConsumptionByIdQueryHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<Consumption> Handle(GetConsumptionByIdQuery request, CancellationToken cancellationToken)
        {
            var consumption = await _context.Consumptions.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (consumption != null)
            {
                return consumption;
            }

            throw new Exception("Consumption was not found!");
        }
    }
}
