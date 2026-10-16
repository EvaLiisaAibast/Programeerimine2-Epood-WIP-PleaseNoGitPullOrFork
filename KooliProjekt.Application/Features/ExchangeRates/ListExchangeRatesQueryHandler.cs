using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class ListExchangeRatesQueryHandler : IRequestHandler<ListExchangeRatesQuery, IEnumerable<ExchangeRate>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListExchangeRatesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ExchangeRate>> Handle(ListExchangeRatesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ExchangeRates.ToListAsync(cancellationToken);

            return result;
        }
    }
}
