using System.Threading.Tasks;
using KooliProjekt.Application.Features.LoyaltyPoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LoyaltyPointsEntity = KooliProjekt.Application.Data.LoyaltyPoints;

namespace KooliProjekt.WebAPI.Controllers
{
    public class LoyaltyPointsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public LoyaltyPointsController(IMediator mediator)
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

            var query = new GetLoyaltyPointsQuery { Id = id };
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
            var query = new ListLoyaltyPointsQuery();
            var result = await _mediator.Send(query);

            return Json(result);
        }
    }
}
