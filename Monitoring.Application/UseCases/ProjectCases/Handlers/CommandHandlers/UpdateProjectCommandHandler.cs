using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.ProjectCases.Commands;
using Monitoring.Domain.DTOs;

namespace Monitoring.Application.UseCases.ProjectCases.Handlers.CommandHandlers
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public UpdateProjectCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project != null)
            {
                project.ClientName = request.ClientName;
                project.PhoneNumber = request.PhoneNumber;
                project.ProjectName = request.ProjectName;
                project.Amount = request.Amount;
                project.BudgetTarget = request.BudgetTarget;
                project.Received = request.Received;
                project.StartingDate = request.StartingDate;
                project.EndingDate = request.EndingDate;
                project.EmployeePercent = request.EmployeePercent;

                _context.Projects.Update(project);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Project was updated successfully!",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Project was not found!",
                StatusCode = 404
            };
        }
    }
}
