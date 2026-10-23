using System.Threading.Tasks;
using KooliProjekt.Application.Features.ReturnLines;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class ReturnLinesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ReturnLinesController(IMediator mediator)
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

            var query = new GetReturnLineQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListReturnLinesQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
