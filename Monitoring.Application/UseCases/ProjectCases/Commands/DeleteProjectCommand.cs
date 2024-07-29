using MediatR;
using Monitoring.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ProjectCases.Commands
{
    public class DeleteProjectCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
