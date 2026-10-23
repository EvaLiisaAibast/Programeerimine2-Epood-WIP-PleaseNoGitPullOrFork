using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class ListPurchaseOrdersQuery : IRequest<OperationResult<PagedResult<PurchaseOrderListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
