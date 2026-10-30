using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Refunds
{
    public class SaveRefundCommandHandler : IRequestHandler<SaveRefundCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveRefundCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveRefundCommand request, CancellationToken cancellationToken)
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

            Refund entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Refunds.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Refund();
                _dbContext.Refunds.Add(entity);
            }

            entity.PaymentId = request.Data.PaymentId;
            entity.Amount = request.Data.Amount;
            entity.Reason = request.Data.Reason;
            entity.Status = request.Data.Status;
            entity.CreatedAt = request.Data.CreatedAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
