using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.StockLevels
{
    public class ListStockLevelsQueryHandler : IRequestHandler<ListStockLevelsQuery, IEnumerable<StockLevel>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListStockLevelsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StockLevel>> Handle(ListStockLevelsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.StockLevels.ToListAsync(cancellationToken);

            return result;
        }
    }
}
