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
    public class DeleteConsumptionCommandHandler : IRequestHandler<DeleteConsumptionCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public DeleteConsumptionCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteConsumptionCommand request, CancellationToken cancellationToken)
        {
            var consumption = await _context.Consumptions.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (consumption != null)
            {
                _context.Consumptions.Remove(consumption);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Consumption was deleted successfully!",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Consumption was not found!",
                StatusCode = 404
            };
        }
    }
}
