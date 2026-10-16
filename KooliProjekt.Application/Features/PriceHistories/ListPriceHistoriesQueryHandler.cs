using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.PriceHistories
{
    public class ListPriceHistoriesQueryHandler : IRequestHandler<ListPriceHistoriesQuery, IEnumerable<PriceHistory>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPriceHistoriesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PriceHistory>> Handle(ListPriceHistoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.PriceHistories.ToListAsync(cancellationToken);

            return result;
        }
    }
}
