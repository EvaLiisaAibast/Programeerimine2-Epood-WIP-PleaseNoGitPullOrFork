using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class SavePurchaseOrderLineCommandHandler : IRequestHandler<SavePurchaseOrderLineCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SavePurchaseOrderLineCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SavePurchaseOrderLineCommand request, CancellationToken cancellationToken)
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

            PurchaseOrderLine entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.PurchaseOrderLines.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new PurchaseOrderLine();
                _dbContext.PurchaseOrderLines.Add(entity);
            }

            entity.PurchaseOrderId = request.Data.PurchaseOrderId;
            entity.VariantId = request.Data.VariantId;
            entity.OrderedQuantity = request.Data.OrderedQuantity;
            entity.ReceivedQuantity = request.Data.ReceivedQuantity;
            entity.PurchasePrice = request.Data.PurchasePrice;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
