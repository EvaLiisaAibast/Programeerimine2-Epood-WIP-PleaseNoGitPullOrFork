using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class SaveWarehouseTransferLineCommandHandler : IRequestHandler<SaveWarehouseTransferLineCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveWarehouseTransferLineCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveWarehouseTransferLineCommand request, CancellationToken cancellationToken)
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

            WarehouseTransferLine entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.WarehouseTransferLines.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new WarehouseTransferLine();
                _dbContext.WarehouseTransferLines.Add(entity);
            }

            entity.TransferId = request.Data.TransferId;
            entity.VariantId = request.Data.VariantId;
            entity.Quantity = request.Data.Quantity;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
