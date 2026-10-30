using System.Threading.Tasks;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Features.Refunds;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class RefundsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public RefundsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var query = new GetRefundQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListRefundsQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] RefundDto data)
        {
            var command = new SaveRefundCommand { Data = data };
            var result = await _mediator.Send(command);

            return Result(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var command = new DeleteRefundCommand { Id = id };
            var result = await _mediator.Send(command);

            return Result(result);
        }
    }
}
