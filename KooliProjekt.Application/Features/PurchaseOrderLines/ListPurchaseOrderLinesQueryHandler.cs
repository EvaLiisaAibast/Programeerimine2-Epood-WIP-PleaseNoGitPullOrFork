using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class ListPurchaseOrderLinesQueryHandler : IRequestHandler<ListPurchaseOrderLinesQuery, OperationResult<PagedResult<PurchaseOrderLineListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPurchaseOrderLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<PurchaseOrderLineListItemDto>>> Handle(ListPurchaseOrderLinesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<PurchaseOrderLineListItemDto>>();

            response.Value = await _dbContext.PurchaseOrderLines
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new PurchaseOrderLineListItemDto
                {
                    Id = x.Id,
                    PurchaseOrderId = x.PurchaseOrderId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    OrderedQuantity = x.OrderedQuantity,
                    ReceivedQuantity = x.ReceivedQuantity,
                    PurchasePrice = x.PurchasePrice,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
