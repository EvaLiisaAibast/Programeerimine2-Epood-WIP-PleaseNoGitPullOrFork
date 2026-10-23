using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class ListCampaignProductsQuery : IRequest<OperationResult<PagedResult<CampaignProductListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
