using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class SaveOrderStatusHistoryCommandHandler : IRequestHandler<SaveOrderStatusHistoryCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveOrderStatusHistoryCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveOrderStatusHistoryCommand request, CancellationToken cancellationToken)
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

            OrderStatusHistory entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.OrderStatusHistories.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new OrderStatusHistory();
                _dbContext.OrderStatusHistories.Add(entity);
            }

            entity.OrderId = request.Data.OrderId;
            entity.OldStatus = request.Data.OldStatus;
            entity.NewStatus = request.Data.NewStatus;
            entity.ModifiedAt = request.Data.ModifiedAt;
            entity.ChangedBy = request.Data.ChangedBy;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
