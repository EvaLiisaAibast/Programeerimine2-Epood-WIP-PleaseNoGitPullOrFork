using System.Threading.Tasks;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Features.OrderLines;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class OrderLinesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public OrderLinesController(IMediator mediator)
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

            var query = new GetOrderLineQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListOrderLinesQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] OrderLineDto data)
        {
            var command = new SaveOrderLineCommand { Data = data };
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

            var command = new DeleteOrderLineCommand { Id = id };
            var result = await _mediator.Send(command);

            return Result(result);
        }
    }
}
