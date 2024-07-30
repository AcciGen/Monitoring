using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.ProjectCases.Commands;
using Monitoring.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ProjectCases.Handlers.CommandHandlers
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public DeleteProjectCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (project != null)
            {
                _context.Projects.Remove(project);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Project was deleted successfully!",
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
