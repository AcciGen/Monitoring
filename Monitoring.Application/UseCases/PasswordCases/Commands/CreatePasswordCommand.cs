using MediatR;
using Monitoring.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.PasswordCases.Commands
{
    public class CreatePasswordCommand : IRequest<ResponseModel>
    {
        public string Program { get; set; }
        public string Login { get; set; }
        public string? Pass { get; set; }
        public Guid ProjectId { get; set; }
    }
}
