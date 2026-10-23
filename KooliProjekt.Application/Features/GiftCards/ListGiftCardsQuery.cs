using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class ListGiftCardsQuery : IRequest<OperationResult<PagedResult<GiftCardListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
