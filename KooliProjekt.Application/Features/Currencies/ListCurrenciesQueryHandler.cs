using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Currencies
{
    public class ListCurrenciesQueryHandler : IRequestHandler<ListCurrenciesQuery, IEnumerable<Currency>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCurrenciesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Currency>> Handle(ListCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Currencies.ToListAsync(cancellationToken);

            return result;
        }
    }
}
