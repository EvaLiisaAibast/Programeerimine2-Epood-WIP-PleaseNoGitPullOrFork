using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class GetPurchaseOrderLineQueryHandler : IRequestHandler<GetPurchaseOrderLineQuery, OperationResult<PurchaseOrderLineDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetPurchaseOrderLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PurchaseOrderLineDto>> Handle(GetPurchaseOrderLineQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PurchaseOrderLineDto>();

            response.Value = await _dbContext.PurchaseOrderLines
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new PurchaseOrderLineDto
                {
                    Id = x.Id,
                    PurchaseOrderId = x.PurchaseOrderId,
                    VariantId = x.VariantId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    OrderedQuantity = x.OrderedQuantity,
                    ReceivedQuantity = x.ReceivedQuantity,
                    PurchasePrice = x.PurchasePrice,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
