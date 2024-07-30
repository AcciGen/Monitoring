using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.PasswordCases.Queries;
using Monitoring.Domain.Entities;

namespace Monitoring.Application.UseCases.PasswordCases.Handlers.QueryHandlers
{
    public class GetAllPasswordsQueryHandler : IRequestHandler<GetAllPasswordsQuery, IEnumerable<Password>>
    {
        private readonly IMonitoringDbContext _context;

        public GetAllPasswordsQueryHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Password>> Handle(GetAllPasswordsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Passwords.ToListAsync(cancellationToken);
        }
    }
}
