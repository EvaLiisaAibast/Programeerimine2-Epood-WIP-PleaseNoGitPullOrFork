using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class ListCampaignsQueryHandler : IRequestHandler<ListCampaignsQuery, OperationResult<PagedResult<CampaignListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCampaignsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CampaignListItemDto>>> Handle(ListCampaignsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CampaignListItemDto>>();

            response.Value = await _dbContext.Campaigns
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CampaignListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = x.Status,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
