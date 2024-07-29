﻿using MediatR;
using Monitoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Application.UseCases.ProjectCases.Queries
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<Project>>
    {
    }
}
