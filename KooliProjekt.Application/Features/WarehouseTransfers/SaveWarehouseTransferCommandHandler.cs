using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class SaveWarehouseTransferCommandHandler : IRequestHandler<SaveWarehouseTransferCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveWarehouseTransferCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveWarehouseTransferCommand request, CancellationToken cancellationToken)
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

            WarehouseTransfer entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.WarehouseTransfers.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new WarehouseTransfer();
                _dbContext.WarehouseTransfers.Add(entity);
            }

            entity.FromWarehouseId = request.Data.FromWarehouseId;
            entity.ToWarehouseId = request.Data.ToWarehouseId;
            entity.Status = request.Data.Status;
            entity.CreatedAt = request.Data.CreatedAt;
            entity.CompletedAt = request.Data.CompletedAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
