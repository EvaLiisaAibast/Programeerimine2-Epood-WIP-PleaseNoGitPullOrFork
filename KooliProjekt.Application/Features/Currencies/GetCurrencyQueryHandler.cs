using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Currencies
{
    public class GetCurrencyQueryHandler : IRequestHandler<GetCurrencyQuery, Currency>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCurrencyQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Currency> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Currencies.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
