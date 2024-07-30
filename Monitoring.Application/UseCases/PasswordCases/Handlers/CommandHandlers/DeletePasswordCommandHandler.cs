using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitoring.Application.Abstractions;
using Monitoring.Application.UseCases.PasswordCases.Commands;
using Monitoring.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.PasswordCases.Handlers.CommandHandlers
{
    public class DeletePasswordCommandHandler : IRequestHandler<DeletePasswordCommand, ResponseModel>
    {
        private readonly IMonitoringDbContext _context;

        public DeletePasswordCommandHandler(IMonitoringDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeletePasswordCommand request, CancellationToken cancellationToken)
        {
            var password = await _context.Passwords.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (password != null)
            {
                _context.Passwords.Remove(password);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Password was deleted successfully!",
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
