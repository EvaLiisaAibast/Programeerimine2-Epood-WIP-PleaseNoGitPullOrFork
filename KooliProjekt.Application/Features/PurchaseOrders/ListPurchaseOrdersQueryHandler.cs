using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class ListPurchaseOrdersQueryHandler : IRequestHandler<ListPurchaseOrdersQuery, OperationResult<PagedResult<PurchaseOrderListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPurchaseOrdersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<PurchaseOrderListItemDto>>> Handle(ListPurchaseOrdersQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<PurchaseOrderListItemDto>>();

            response.Value = await _dbContext.PurchaseOrders
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new PurchaseOrderListItemDto
                {
                    Id = x.Id,
                    SupplierName = _dbContext.Suppliers.Where(t => t.Id == x.SupplierId).Select(t => t.Name).FirstOrDefault(),
                    OrderedAt = x.OrderedAt,
                    ExpectedAt = x.ExpectedAt,
                    Status = x.Status,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
