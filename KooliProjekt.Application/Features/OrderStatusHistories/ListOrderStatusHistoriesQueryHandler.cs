using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class ListOrderStatusHistoriesQueryHandler : IRequestHandler<ListOrderStatusHistoriesQuery, IEnumerable<OrderStatusHistory>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOrderStatusHistoriesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderStatusHistory>> Handle(ListOrderStatusHistoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.OrderStatusHistories.ToListAsync(cancellationToken);

            return result;
        }
    }
}
