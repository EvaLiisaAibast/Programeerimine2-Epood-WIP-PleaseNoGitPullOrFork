using System.Threading.Tasks;
using KooliProjekt.Application.Features.ShoppingCarts;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace KooliProjekt.WebAPI.Controllers
{
    public class ShoppingCartsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartsController(IMediator mediator)
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

            var query = new GetShoppingCartQuery { Id = id };
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
            var query = new ListShoppingCartsQuery();
            var result = await _mediator.Send(query);

            return Json(result);
        }
    }
}
