using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class ListShipmentTrackingsQueryHandler : IRequestHandler<ListShipmentTrackingsQuery, IEnumerable<ShipmentTracking>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListShipmentTrackingsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ShipmentTracking>> Handle(ListShipmentTrackingsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ShipmentTrackings.ToListAsync(cancellationToken);

            return result;
        }
    }
}
