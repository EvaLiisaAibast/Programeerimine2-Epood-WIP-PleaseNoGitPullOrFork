using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class GetStockMovementQueryHandler : IRequestHandler<GetStockMovementQuery, OperationResult<StockMovementDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetStockMovementQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<StockMovementDto>> Handle(GetStockMovementQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<StockMovementDto>();

            response.Value = await _dbContext.StockMovements
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new StockMovementDto
                {
                    Id = x.Id,
                    StockLevelId = x.StockLevelId,
                    Type = x.Type,
                    Quantity = x.Quantity,
                    Reason = x.Reason,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
