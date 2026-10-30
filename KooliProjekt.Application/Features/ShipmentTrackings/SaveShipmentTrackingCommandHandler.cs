using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class SaveShipmentTrackingCommandHandler : IRequestHandler<SaveShipmentTrackingCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveShipmentTrackingCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveShipmentTrackingCommand request, CancellationToken cancellationToken)
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

            ShipmentTracking entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.ShipmentTrackings.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new ShipmentTracking();
                _dbContext.ShipmentTrackings.Add(entity);
            }

            entity.ShipmentId = request.Data.ShipmentId;
            entity.Status = request.Data.Status;
            entity.Location = request.Data.Location;
            entity.Timestamp = request.Data.Timestamp;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
