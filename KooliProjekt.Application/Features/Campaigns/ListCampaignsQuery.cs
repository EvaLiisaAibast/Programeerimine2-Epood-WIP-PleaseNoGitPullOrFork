using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class ListCampaignsQuery : IRequest<OperationResult<PagedResult<CampaignListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
