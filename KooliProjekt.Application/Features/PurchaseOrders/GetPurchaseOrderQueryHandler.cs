using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class GetPurchaseOrderQueryHandler : IRequestHandler<GetPurchaseOrderQuery, PurchaseOrder>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetPurchaseOrderQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PurchaseOrder> Handle(GetPurchaseOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.PurchaseOrders.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
