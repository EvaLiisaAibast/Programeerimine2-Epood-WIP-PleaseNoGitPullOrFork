using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Shipments
{
    public class GetShipmentQueryHandler : IRequestHandler<GetShipmentQuery, Shipment>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetShipmentQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Shipment> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Shipments.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
