using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Application.UseCases.ConsumptionCases.Commands;
using Monitoring.Application.UseCases.ConsumptionCases.Queries;
using Monitoring.Application.UseCases.ProjectCases.Commands;
using Monitoring.Application.UseCases.ProjectCases.Queries;
using Monitoring.Domain.DTOs;
using Monitoring.Domain.Entities;

namespace Monitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsumptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateConsumptionCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Consumption>> GetAll()
        {
            var result = await _mediator.Send(new GetAllConsumptionQuery());

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Consumption> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetConsumptionByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdateConsumptionCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteConsumptionCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }
    }
}
