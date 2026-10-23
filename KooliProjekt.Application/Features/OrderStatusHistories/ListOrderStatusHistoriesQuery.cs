using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class ListOrderStatusHistoriesQuery : IRequest<OperationResult<PagedResult<OrderStatusHistoryListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
