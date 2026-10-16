using System.Threading.Tasks;
using KooliProjekt.Application.Features.LoyaltyAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace KooliProjekt.WebAPI.Controllers
{
    public class LoyaltyAccountsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public LoyaltyAccountsController(IMediator mediator)
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

            var query = new GetLoyaltyAccountQuery { Id = id };
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
            var query = new ListLoyaltyAccountsQuery();
            var result = await _mediator.Send(query);

            return Json(result);
        }
    }
}
