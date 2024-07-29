using MediatR;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.ConsumptionCases.Commands;
using Monitoring.Domain.DTOs;
using Monitoring.Domain.Entities;

namespace Monitoring.Application.UseCases.ConsumptionCases.Handlers.CommandHandlers
{
    public class CreateConsumptionCommandHandler : IRequestHandler<CreateConsumptionCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public CreateConsumptionCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateConsumptionCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var newConsumption = new Consumption()
                {
                    WhyNeeded = request.WhyNeeded,
                    Description = request.Description,
                    Amount = request.Amount
                };

                await _context.Consumptions.AddAsync(newConsumption, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"New consumption was created successfully!",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "You forgot to write something there...",
                StatusCode = 400
            };
        }
    }
}
