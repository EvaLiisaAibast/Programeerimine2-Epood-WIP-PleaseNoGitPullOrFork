using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class ListWarehouseTransferLinesQueryHandler : IRequestHandler<ListWarehouseTransferLinesQuery, OperationResult<PagedResult<WarehouseTransferLineListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWarehouseTransferLinesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<WarehouseTransferLineListItemDto>>> Handle(ListWarehouseTransferLinesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<WarehouseTransferLineListItemDto>>();

            response.Value = await _dbContext.WarehouseTransferLines
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new WarehouseTransferLineListItemDto
                {
                    Id = x.Id,
                    TransferId = x.TransferId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    Quantity = x.Quantity,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
