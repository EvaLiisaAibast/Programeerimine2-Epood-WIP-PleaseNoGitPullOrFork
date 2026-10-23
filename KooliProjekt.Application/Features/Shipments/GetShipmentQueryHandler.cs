using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Shipments
{
    public class GetShipmentQueryHandler : IRequestHandler<GetShipmentQuery, OperationResult<ShipmentDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetShipmentQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ShipmentDto>> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ShipmentDto>();

            response.Value = await _dbContext.Shipments
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ShipmentDto
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    OrderNumber = _dbContext.Orders.Where(t => t.Id == x.OrderId).Select(t => t.OrderNumber).FirstOrDefault(),
                    WarehouseId = x.WarehouseId,
                    WarehouseName = _dbContext.Warehouses.Where(t => t.Id == x.WarehouseId).Select(t => t.Name).FirstOrDefault(),
                    CarrierId = x.CarrierId,
                    CarrierName = _dbContext.Carriers.Where(t => t.Id == x.CarrierId).Select(t => t.Name).FirstOrDefault(),
                    TrackingNumber = x.TrackingNumber,
                    SentAt = x.SentAt,
                    EstimatedDelivery = x.EstimatedDelivery,
                    DeliveredAt = x.DeliveredAt,
                    Status = x.Status,
                    Trackings = _dbContext.ShipmentTrackings
                        .Where(c => c.ShipmentId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new ShipmentTrackingDto
                        {
                            Id = c.Id,
                            ShipmentId = c.ShipmentId,
                            Status = c.Status,
                            Location = c.Location,
                            Timestamp = c.Timestamp,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
