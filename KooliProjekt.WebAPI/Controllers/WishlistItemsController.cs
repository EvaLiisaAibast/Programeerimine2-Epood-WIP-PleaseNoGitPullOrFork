using System.Threading.Tasks;
using KooliProjekt.Application.Features.WishlistItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class WishlistItemsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public WishlistItemsController(IMediator mediator)
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

            var query = new GetWishlistItemQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListWishlistItemsQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
