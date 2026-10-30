using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class SaveReturnLineCommandHandler : IRequestHandler<SaveReturnLineCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveReturnLineCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveReturnLineCommand request, CancellationToken cancellationToken)
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

            ReturnLine entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.ReturnLines.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new ReturnLine();
                _dbContext.ReturnLines.Add(entity);
            }

            entity.ReturnRequestId = request.Data.ReturnRequestId;
            entity.OrderLineId = request.Data.OrderLineId;
            entity.Quantity = request.Data.Quantity;
            entity.Reason = request.Data.Reason;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
