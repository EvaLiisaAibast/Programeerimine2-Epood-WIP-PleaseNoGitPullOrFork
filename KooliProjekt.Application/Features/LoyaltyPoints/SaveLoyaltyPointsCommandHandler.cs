using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class SaveLoyaltyPointsCommandHandler : IRequestHandler<SaveLoyaltyPointsCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveLoyaltyPointsCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveLoyaltyPointsCommand request, CancellationToken cancellationToken)
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

            KooliProjekt.Application.Data.LoyaltyPoints entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.LoyaltyPoints.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new KooliProjekt.Application.Data.LoyaltyPoints();
                _dbContext.LoyaltyPoints.Add(entity);
            }

            entity.AccountId = request.Data.AccountId;
            entity.Points = request.Data.Points;
            entity.Reason = request.Data.Reason;
            entity.CreatedAt = request.Data.CreatedAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
