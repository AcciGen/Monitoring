using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Application.UseCases.PasswordCases.Commands;
using Monitoring.Application.UseCases.PasswordCases.Queries;
using Monitoring.Domain.DTOs;
using Monitoring.Domain.Entities;

namespace Monitoring.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PasswordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreatePasswordCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Password>> GetAll()
        {
            var result = await _mediator.Send(new GetAllPasswordsQuery());

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Password> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPasswordByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdatePasswordCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeletePasswordCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }
    }
}
