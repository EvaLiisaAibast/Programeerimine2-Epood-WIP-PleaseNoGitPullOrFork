using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class ListPurchaseOrderLinesQueryHandler : IRequestHandler<ListPurchaseOrderLinesQuery, IEnumerable<PurchaseOrderLine>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPurchaseOrderLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PurchaseOrderLine>> Handle(ListPurchaseOrderLinesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.PurchaseOrderLines.ToListAsync(cancellationToken);

            return result;
        }
    }
}
