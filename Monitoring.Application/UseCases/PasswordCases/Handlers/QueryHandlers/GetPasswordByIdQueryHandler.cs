using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.PasswordCases.Queries;
using Monitoring.Domain.Entities;

namespace Monitoring.Application.UseCases.PasswordCases.Handlers.QueryHandlers
{
    public class GetPasswordByIdQueryHandler : IRequestHandler<GetPasswordByIdQuery, Password>
    {
        private readonly IMonitoringDbContext _context;

        public GetPasswordByIdQueryHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<Password> Handle(GetPasswordByIdQuery request, CancellationToken cancellationToken)
        {
            var password = await _context.Passwords.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (password != null)
            {
                return password;
            }

            throw new Exception("Password was not found!");
        }
    }
}
