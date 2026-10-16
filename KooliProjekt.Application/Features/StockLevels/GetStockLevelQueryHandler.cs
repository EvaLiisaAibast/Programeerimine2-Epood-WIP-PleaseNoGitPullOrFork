using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.StockLevels
{
    public class GetStockLevelQueryHandler : IRequestHandler<GetStockLevelQuery, StockLevel>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetStockLevelQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StockLevel> Handle(GetStockLevelQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.StockLevels.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
