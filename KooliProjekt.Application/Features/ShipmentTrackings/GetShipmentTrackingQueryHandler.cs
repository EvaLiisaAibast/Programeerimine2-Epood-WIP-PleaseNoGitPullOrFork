using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class GetShipmentTrackingQueryHandler : IRequestHandler<GetShipmentTrackingQuery, OperationResult<ShipmentTrackingDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetShipmentTrackingQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ShipmentTrackingDto>> Handle(GetShipmentTrackingQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ShipmentTrackingDto>();

            response.Value = await _dbContext.ShipmentTrackings
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ShipmentTrackingDto
                {
                    Id = x.Id,
                    ShipmentId = x.ShipmentId,
                    Status = x.Status,
                    Location = x.Location,
                    Timestamp = x.Timestamp,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
