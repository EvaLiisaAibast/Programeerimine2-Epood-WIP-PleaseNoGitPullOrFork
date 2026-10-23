using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class ListStockMovementsQueryHandler : IRequestHandler<ListStockMovementsQuery, OperationResult<PagedResult<StockMovementListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListStockMovementsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<StockMovementListItemDto>>> Handle(ListStockMovementsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<StockMovementListItemDto>>();

            response.Value = await _dbContext.StockMovements
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new StockMovementListItemDto
                {
                    Id = x.Id,
                    StockLevelId = x.StockLevelId,
                    Type = x.Type,
                    Quantity = x.Quantity,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
