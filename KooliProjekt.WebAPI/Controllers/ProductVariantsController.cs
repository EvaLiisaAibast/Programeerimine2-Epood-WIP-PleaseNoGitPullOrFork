using System.Threading.Tasks;
using KooliProjekt.Application.Features.ProductVariants;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace KooliProjekt.WebAPI.Controllers
{
    public class ProductVariantsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ProductVariantsController(IMediator mediator)
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

            var query = new GetProductVariantQuery { Id = id };
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
            var query = new ListProductVariantsQuery();
            var result = await _mediator.Send(query);

            return Json(result);
        }
    }
}
