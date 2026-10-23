using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class ListShipmentTrackingsQueryHandler : IRequestHandler<ListShipmentTrackingsQuery, OperationResult<PagedResult<ShipmentTrackingListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListShipmentTrackingsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ShipmentTrackingListItemDto>>> Handle(ListShipmentTrackingsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ShipmentTrackingListItemDto>>();

            response.Value = await _dbContext.ShipmentTrackings
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ShipmentTrackingListItemDto
                {
                    Id = x.Id,
                    ShipmentId = x.ShipmentId,
                    Status = x.Status,
                    Location = x.Location,
                    Timestamp = x.Timestamp,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
