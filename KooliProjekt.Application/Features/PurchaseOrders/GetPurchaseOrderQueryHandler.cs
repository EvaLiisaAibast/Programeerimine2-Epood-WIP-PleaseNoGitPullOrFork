using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class GetPurchaseOrderQueryHandler : IRequestHandler<GetPurchaseOrderQuery, OperationResult<PurchaseOrderDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetPurchaseOrderQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PurchaseOrderDto>> Handle(GetPurchaseOrderQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PurchaseOrderDto>();

            response.Value = await _dbContext.PurchaseOrders
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new PurchaseOrderDto
                {
                    Id = x.Id,
                    SupplierId = x.SupplierId,
                    SupplierName = _dbContext.Suppliers.Where(t => t.Id == x.SupplierId).Select(t => t.Name).FirstOrDefault(),
                    WarehouseId = x.WarehouseId,
                    WarehouseName = _dbContext.Warehouses.Where(t => t.Id == x.WarehouseId).Select(t => t.Name).FirstOrDefault(),
                    OrderedAt = x.OrderedAt,
                    ExpectedAt = x.ExpectedAt,
                    Status = x.Status,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
