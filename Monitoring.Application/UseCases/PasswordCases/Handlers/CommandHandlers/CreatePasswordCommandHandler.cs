using MediatR;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.PasswordCases.Commands;
using Monitoring.Domain.DTOs;
using Monitoring.Domain.Entities;

namespace Monitoring.Application.UseCases.PasswordCases.Handlers.CommandHandlers
{
    public class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public CreatePasswordCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var newPassword = new Password()
                {
                    Program = request.Program,
                    Login = request.Login,
                    Pass = request.Pass ?? null,
                    ProjectId = request.ProjectId
                };

                await _context.Passwords.AddAsync(newPassword, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"New password was created successfully!",
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
