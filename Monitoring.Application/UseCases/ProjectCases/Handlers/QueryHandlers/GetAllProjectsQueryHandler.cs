using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.ProjectCases.Queries;
using Monitoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ProjectCases.Handlers.QueryHandlers
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
    {
        private readonly IMonitoringDbContext _context;

        public GetAllProjectsQueryHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Projects.ToListAsync(cancellationToken);
        }
    }
}
