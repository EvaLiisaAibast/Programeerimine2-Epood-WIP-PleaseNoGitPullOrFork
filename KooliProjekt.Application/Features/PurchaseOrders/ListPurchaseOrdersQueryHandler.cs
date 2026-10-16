using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class ListPurchaseOrdersQueryHandler : IRequestHandler<ListPurchaseOrdersQuery, IEnumerable<PurchaseOrder>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPurchaseOrdersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PurchaseOrder>> Handle(ListPurchaseOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.PurchaseOrders.ToListAsync(cancellationToken);

            return result;
        }
    }
}
