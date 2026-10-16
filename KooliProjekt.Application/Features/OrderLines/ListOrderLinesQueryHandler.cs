using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.OrderLines
{
    public class ListOrderLinesQueryHandler : IRequestHandler<ListOrderLinesQuery, IEnumerable<OrderLine>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOrderLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderLine>> Handle(ListOrderLinesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.OrderLines.ToListAsync(cancellationToken);

            return result;
        }
    }
}
