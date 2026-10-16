using System.Threading.Tasks;
using KooliProjekt.Application.Features.PurchaseOrderLines;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace KooliProjekt.WebAPI.Controllers
{
    public class PurchaseOrderLinesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseOrderLinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }

            var query = new GetPurchaseOrderLineQuery { Id = id };
            var result = await _mediator.Send(query);

            if(result == null)
            {
                return NotFound();
            }

            return Json(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var query = new ListPurchaseOrderLinesQuery();
            var result = await _mediator.Send(query);

            return Json(result);
        }
    }
}
