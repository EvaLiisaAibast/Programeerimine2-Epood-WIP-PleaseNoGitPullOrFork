using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Warehouses
{
    public class ListWarehousesQuery : IRequest<OperationResult<PagedResult<WarehouseListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
