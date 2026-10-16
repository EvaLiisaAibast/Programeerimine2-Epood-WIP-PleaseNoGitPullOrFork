using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.StockMovements
{
    public class ListStockMovementsQueryHandler : IRequestHandler<ListStockMovementsQuery, IEnumerable<StockMovement>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListStockMovementsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StockMovement>> Handle(ListStockMovementsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.StockMovements.ToListAsync(cancellationToken);

            return result;
        }
    }
}
