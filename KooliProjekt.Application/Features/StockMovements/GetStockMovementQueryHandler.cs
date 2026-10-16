using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.StockMovements
{
    public class GetStockMovementQueryHandler : IRequestHandler<GetStockMovementQuery, StockMovement>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetStockMovementQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StockMovement> Handle(GetStockMovementQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.StockMovements.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
