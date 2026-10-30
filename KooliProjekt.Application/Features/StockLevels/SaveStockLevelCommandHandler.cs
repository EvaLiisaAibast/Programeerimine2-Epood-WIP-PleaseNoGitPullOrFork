using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.StockLevels
{
    public class SaveStockLevelCommandHandler : IRequestHandler<SaveStockLevelCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveStockLevelCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveStockLevelCommand request, CancellationToken cancellationToken)
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

            StockLevel entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.StockLevels.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new StockLevel();
                _dbContext.StockLevels.Add(entity);
            }

            entity.WarehouseId = request.Data.WarehouseId;
            entity.VariantId = request.Data.VariantId;
            entity.Quantity = request.Data.Quantity;
            entity.Reserved = request.Data.Reserved;
            entity.MinimumStock = request.Data.MinimumStock;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
