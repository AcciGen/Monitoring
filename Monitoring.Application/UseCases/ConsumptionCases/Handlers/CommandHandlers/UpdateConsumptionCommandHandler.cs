using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.ConsumptionCases.Commands;
using Monitoring.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ConsumptionCases.Handlers.CommandHandlers
{
    public class UpdateConsumptionCommandHandler : IRequestHandler<UpdateConsumptionCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public UpdateConsumptionCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateConsumptionCommand request, CancellationToken cancellationToken)
        {
            var consumption = await _context.Consumptions.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (consumption != null)
            {
                consumption.WhyNeeded = request.WhyNeeded;
                consumption.Description = request.Description;
                consumption.Amount = request.Amount;

                _context.Consumptions.Update(consumption);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Consumption was updated successfully!",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Consumption was not found!",
                StatusCode = 400
            };
        }
    }
}
