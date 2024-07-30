using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.PasswordCases.Commands;
using Monitoring.Domain.DTOs;

namespace Monitoring.Application.UseCases.PasswordCases.Handlers.CommandHandlers
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public UpdatePasswordCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var password = await _context.Passwords.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (password != null)
            {
                password.Program = request.Program;
                password.Login = request.Login;
                password.Pass = request.Pass;
                password.ProjectId = request.ProjectId;

                _context.Passwords.Update(password);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Password was updated successfully!",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Password was not found!",
                StatusCode = 404
            };
        }
    }
}
