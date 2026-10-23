using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class ListWarehouseTransfersQuery : IRequest<OperationResult<PagedResult<WarehouseTransferListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
