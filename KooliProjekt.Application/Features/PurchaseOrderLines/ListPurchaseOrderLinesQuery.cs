using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class ListPurchaseOrderLinesQuery : IRequest<OperationResult<PagedResult<PurchaseOrderLineListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
