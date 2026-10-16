using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.PriceHistories
{
    public class GetPriceHistoryQueryHandler : IRequestHandler<GetPriceHistoryQuery, PriceHistory>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetPriceHistoryQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PriceHistory> Handle(GetPriceHistoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.PriceHistories.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
