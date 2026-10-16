using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class GetExchangeRateQueryHandler : IRequestHandler<GetExchangeRateQuery, ExchangeRate>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetExchangeRateQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExchangeRate> Handle(GetExchangeRateQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ExchangeRates.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
