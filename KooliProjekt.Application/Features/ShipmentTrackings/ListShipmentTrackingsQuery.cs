using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class ListShipmentTrackingsQuery : IRequest<OperationResult<PagedResult<ShipmentTrackingListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
