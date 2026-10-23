using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class ListLoyaltyPointsQuery : IRequest<OperationResult<PagedResult<LoyaltyPointsListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
