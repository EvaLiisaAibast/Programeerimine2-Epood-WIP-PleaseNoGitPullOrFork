using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.StockLevels
{
    public class ListStockLevelsQuery : IRequest<OperationResult<PagedResult<StockLevelListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
