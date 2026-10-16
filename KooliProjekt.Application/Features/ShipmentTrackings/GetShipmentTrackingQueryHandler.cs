using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class GetShipmentTrackingQueryHandler : IRequestHandler<GetShipmentTrackingQuery, ShipmentTracking>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetShipmentTrackingQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShipmentTracking> Handle(GetShipmentTrackingQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ShipmentTrackings.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
