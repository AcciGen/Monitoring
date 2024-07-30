using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Application.UseCases.ProjectCases.Commands;
using Monitoring.Application.UseCases.ProjectCases.Queries;
using Monitoring.Domain.DTOs;
using Monitoring.Domain.Entities;

namespace Monitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateProjectCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetAll()
        {
            var result = await _mediator.Send(new GetAllProjectsQuery());

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Project> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdateProjectCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteProjectCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }
    }
}
