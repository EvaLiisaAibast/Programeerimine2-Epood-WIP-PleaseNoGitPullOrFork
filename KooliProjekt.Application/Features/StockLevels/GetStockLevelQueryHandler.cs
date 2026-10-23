using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.StockLevels
{
    public class GetStockLevelQueryHandler : IRequestHandler<GetStockLevelQuery, OperationResult<StockLevelDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetStockLevelQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<StockLevelDto>> Handle(GetStockLevelQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<StockLevelDto>();

            response.Value = await _dbContext.StockLevels
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new StockLevelDto
                {
                    Id = x.Id,
                    WarehouseId = x.WarehouseId,
                    WarehouseName = _dbContext.Warehouses.Where(t => t.Id == x.WarehouseId).Select(t => t.Name).FirstOrDefault(),
                    VariantId = x.VariantId,
                    VariantCode = _dbContext.ProductVariants.Where(t => t.Id == x.VariantId).Select(t => t.ProductCode).FirstOrDefault(),
                    Quantity = x.Quantity,
                    Reserved = x.Reserved,
                    MinimumStock = x.MinimumStock,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
