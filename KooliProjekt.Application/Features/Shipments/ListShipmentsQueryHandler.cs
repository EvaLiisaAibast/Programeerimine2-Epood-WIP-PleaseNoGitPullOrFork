using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Shipments
{
    public class ListShipmentsQueryHandler : IRequestHandler<ListShipmentsQuery, IEnumerable<Shipment>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListShipmentsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Shipment>> Handle(ListShipmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Shipments.ToListAsync(cancellationToken);

            return result;
        }
    }
}
