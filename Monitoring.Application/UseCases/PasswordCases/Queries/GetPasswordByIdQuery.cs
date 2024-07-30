using MediatR;
using Monitoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.PasswordCases.Queries
{
    public class GetPasswordByIdQuery : IRequest<Password>
    {
        public Guid Id { get; set; }
    }
}
