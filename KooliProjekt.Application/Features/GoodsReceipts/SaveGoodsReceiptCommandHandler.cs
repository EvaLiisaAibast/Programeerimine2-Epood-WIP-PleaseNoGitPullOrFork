using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class SaveGoodsReceiptCommandHandler : IRequestHandler<SaveGoodsReceiptCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveGoodsReceiptCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveGoodsReceiptCommand request, CancellationToken cancellationToken)
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

            GoodsReceipt entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.GoodsReceipts.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new GoodsReceipt();
                _dbContext.GoodsReceipts.Add(entity);
            }

            entity.PurchaseOrderLineId = request.Data.PurchaseOrderLineId;
            entity.Quantity = request.Data.Quantity;
            entity.CreatedAt = request.Data.CreatedAt;
            entity.EmployeeId = request.Data.EmployeeId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
