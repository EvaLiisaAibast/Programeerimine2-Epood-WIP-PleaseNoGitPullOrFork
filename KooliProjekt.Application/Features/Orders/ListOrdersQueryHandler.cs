using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Orders
{
    public class ListOrdersQueryHandler : IRequestHandler<ListOrdersQuery, IEnumerable<Order>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOrdersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Orders.ToListAsync(cancellationToken);

            return result;
        }
    }
}
