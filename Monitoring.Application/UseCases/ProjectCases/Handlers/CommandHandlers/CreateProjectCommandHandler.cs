using MediatR;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.PasswordCases.Commands;
using Monitoring.Application.UseCases.ProjectCases.Commands;
using Monitoring.Domain.DTOs;
using Monitoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ProjectCases.Handlers.CommandHandlers
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public CreateProjectCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var newProject = new Project()
                {
                    ClientName = request.ClientName,
                    PhoneNumber = request.PhoneNumber,
                    ProjectName = request.ProjectName,
                    Amount = request.Amount,
                    BudgetTarget = request.BudgetTarget,
                    Received = request.Received ?? null,
                    StartingDate = request.StartingDate,
                    EndingDate = request.EndingDate,
                };

                await _context.Projects.AddAsync(newProject, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"New project was created successfully!",
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
