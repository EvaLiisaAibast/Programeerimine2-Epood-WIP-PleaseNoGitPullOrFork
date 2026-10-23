using System.Threading.Tasks;
using KooliProjekt.Application.Features.VatRates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class VatRatesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public VatRatesController(IMediator mediator)
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

            var query = new GetVatRateQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListVatRatesQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
