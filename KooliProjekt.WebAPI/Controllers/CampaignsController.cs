using System.Threading.Tasks;
using KooliProjekt.Application.Features.Campaigns;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class CampaignsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CampaignsController(IMediator mediator)
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

            var query = new GetCampaignQuery { Id = id };
            var result = await _mediator.Send(query);

            return Result(result);
        }

        [HttpGet("list/{page}/{pageSize}")]
        public async Task<IActionResult> List(int page, int pageSize)
        {
            var query = new ListCampaignsQuery
            {
                Page = page,
                PageSize = pageSize
            };
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
