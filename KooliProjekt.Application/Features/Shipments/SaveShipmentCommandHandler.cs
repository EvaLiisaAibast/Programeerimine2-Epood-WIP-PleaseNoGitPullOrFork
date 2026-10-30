using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Shipments
{
    public class SaveShipmentCommandHandler : IRequestHandler<SaveShipmentCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveShipmentCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveShipmentCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<int>();

            if (request.Data == null)
            {
                return response.AddError("Andmed puuduvad.");
            }

            if (request.Data.Id < 0)
            {
                return response.AddError("Id ei tohi olla negatiivne.");
            }

            Shipment entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Shipments.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Shipment();
                _dbContext.Shipments.Add(entity);
            }

            entity.OrderId = request.Data.OrderId;
            entity.WarehouseId = request.Data.WarehouseId;
            entity.CarrierId = request.Data.CarrierId;
            entity.TrackingNumber = request.Data.TrackingNumber;
            entity.SentAt = request.Data.SentAt;
            entity.EstimatedDelivery = request.Data.EstimatedDelivery;
            entity.DeliveredAt = request.Data.DeliveredAt;
            entity.Status = request.Data.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
