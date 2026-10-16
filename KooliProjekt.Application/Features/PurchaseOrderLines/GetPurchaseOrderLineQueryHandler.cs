using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class GetPurchaseOrderLineQueryHandler : IRequestHandler<GetPurchaseOrderLineQuery, PurchaseOrderLine>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetPurchaseOrderLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PurchaseOrderLine> Handle(GetPurchaseOrderLineQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.PurchaseOrderLines.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
