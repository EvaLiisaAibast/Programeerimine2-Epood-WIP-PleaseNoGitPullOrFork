using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class ListStockMovementsQuery : IRequest<OperationResult<PagedResult<StockMovementListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
