using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.StockLevels
{
    public class ListStockLevelsQueryHandler : IRequestHandler<ListStockLevelsQuery, OperationResult<PagedResult<StockLevelListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListStockLevelsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<StockLevelListItemDto>>> Handle(ListStockLevelsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<StockLevelListItemDto>>();

            response.Value = await _dbContext.StockLevels
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new StockLevelListItemDto
                {
                    Id = x.Id,
                    WarehouseName = _dbContext.Warehouses.Where(t => t.Id == x.WarehouseId).Select(t => t.Name).FirstOrDefault(),
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    Quantity = x.Quantity,
                    Reserved = x.Reserved,
                    MinimumStock = x.MinimumStock,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
