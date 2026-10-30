using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Payments
{
    public class SavePaymentCommandHandler : IRequestHandler<SavePaymentCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SavePaymentCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SavePaymentCommand request, CancellationToken cancellationToken)
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

            Payment entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Payments.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Payment();
                _dbContext.Payments.Add(entity);
            }

            entity.OrderId = request.Data.OrderId;
            entity.Amount = request.Data.Amount;
            entity.Method = request.Data.Method;
            entity.Status = request.Data.Status;
            entity.TransactionReference = request.Data.TransactionReference;
            entity.CreatedAt = request.Data.CreatedAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
