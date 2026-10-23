using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class GetWarehouseTransferQueryHandler : IRequestHandler<GetWarehouseTransferQuery, OperationResult<WarehouseTransferDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetWarehouseTransferQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<WarehouseTransferDto>> Handle(GetWarehouseTransferQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<WarehouseTransferDto>();

            response.Value = await _dbContext.WarehouseTransfers
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new WarehouseTransferDto
                {
                    Id = x.Id,
                    FromWarehouseId = x.FromWarehouseId,
                    FromWarehouseName = _dbContext.Warehouses.Where(t => t.Id == x.FromWarehouseId).Select(t => t.Name).FirstOrDefault(),
                    ToWarehouseId = x.ToWarehouseId,
                    ToWarehouseName = _dbContext.Warehouses.Where(t => t.Id == x.ToWarehouseId).Select(t => t.Name).FirstOrDefault(),
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    CompletedAt = x.CompletedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
