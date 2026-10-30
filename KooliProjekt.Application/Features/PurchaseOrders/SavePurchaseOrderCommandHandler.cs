using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class SavePurchaseOrderCommandHandler : IRequestHandler<SavePurchaseOrderCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SavePurchaseOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SavePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<int>();

            if (request.Data == null)
            {
                return response.AddError("Andmed puuduvad.");
            }

            if (request.Data.Id < 0)
            {
                return response.AddError("Id ei tohi olla negatiivne.");
            }

            PurchaseOrder entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.PurchaseOrders.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new PurchaseOrder();
                _dbContext.PurchaseOrders.Add(entity);
            }

            entity.SupplierId = request.Data.SupplierId;
            entity.WarehouseId = request.Data.WarehouseId;
            entity.OrderedAt = request.Data.OrderedAt;
            entity.ExpectedAt = request.Data.ExpectedAt;
            entity.Status = request.Data.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
