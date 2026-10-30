using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Warehouses
{
    public class SaveWarehouseCommandHandler : IRequestHandler<SaveWarehouseCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveWarehouseCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveWarehouseCommand request, CancellationToken cancellationToken)
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

            Warehouse entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Warehouses.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Warehouse();
                _dbContext.Warehouses.Add(entity);
            }

            entity.Name = request.Data.Name;
            entity.AddressId = request.Data.AddressId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
