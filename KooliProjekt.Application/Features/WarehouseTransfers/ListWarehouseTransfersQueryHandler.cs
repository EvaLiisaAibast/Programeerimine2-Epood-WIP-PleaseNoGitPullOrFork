using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class ListWarehouseTransfersQueryHandler : IRequestHandler<ListWarehouseTransfersQuery, OperationResult<PagedResult<WarehouseTransferListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListWarehouseTransfersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<WarehouseTransferListItemDto>>> Handle(ListWarehouseTransfersQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<WarehouseTransferListItemDto>>();

            response.Value = await _dbContext.WarehouseTransfers
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new WarehouseTransferListItemDto
                {
                    Id = x.Id,
                    FromWarehouseName = _dbContext.Warehouses.Where(t => t.Id == x.FromWarehouseId).Select(t => t.Name).FirstOrDefault(),
                    ToWarehouseName = _dbContext.Warehouses.Where(t => t.Id == x.ToWarehouseId).Select(t => t.Name).FirstOrDefault(),
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
