using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class ListGoodsReceiptsQueryHandler : IRequestHandler<ListGoodsReceiptsQuery, OperationResult<PagedResult<GoodsReceiptListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListGoodsReceiptsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<GoodsReceiptListItemDto>>> Handle(ListGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<GoodsReceiptListItemDto>>();

            response.Value = await _dbContext.GoodsReceipts
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new GoodsReceiptListItemDto
                {
                    Id = x.Id,
                    PurchaseOrderLineId = x.PurchaseOrderLineId,
                    Quantity = x.Quantity,
                    CreatedAt = x.CreatedAt,
                    EmployeeName = _dbContext.Employees.Where(t => t.Id == x.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
