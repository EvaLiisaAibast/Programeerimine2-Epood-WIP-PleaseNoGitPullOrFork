using System.Threading.Tasks;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Features.WarehouseTransfers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class WarehouseTransfersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseTransfersController(IMediator mediator)
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

            var query = new GetWarehouseTransferQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListWarehouseTransfersQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] WarehouseTransferDto data)
        {
            var command = new SaveWarehouseTransferCommand { Data = data };
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

            var command = new DeleteWarehouseTransferCommand { Id = id };
            var result = await _mediator.Send(command);

            return Result(result);
        }
    }
}
