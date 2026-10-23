using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class ListWishlistItemsQuery : IRequest<OperationResult<PagedResult<WishlistItemListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
