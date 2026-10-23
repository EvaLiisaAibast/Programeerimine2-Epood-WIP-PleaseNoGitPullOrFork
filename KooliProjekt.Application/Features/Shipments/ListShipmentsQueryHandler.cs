using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Shipments
{
    public class ListShipmentsQueryHandler : IRequestHandler<ListShipmentsQuery, OperationResult<PagedResult<ShipmentListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListShipmentsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ShipmentListItemDto>>> Handle(ListShipmentsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ShipmentListItemDto>>();

            response.Value = await _dbContext.Shipments
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ShipmentListItemDto
                {
                    Id = x.Id,
                    OrderNumber = _dbContext.Orders.Where(t => t.Id == x.OrderId).Select(t => t.OrderNumber).FirstOrDefault(),
                    CarrierName = _dbContext.Carriers.Where(t => t.Id == x.CarrierId).Select(t => t.Name).FirstOrDefault(),
                    TrackingNumber = x.TrackingNumber,
                    Status = x.Status,
                    EstimatedDelivery = x.EstimatedDelivery,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
