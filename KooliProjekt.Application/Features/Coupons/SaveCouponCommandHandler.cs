using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Coupons
{
    public class SaveCouponCommandHandler : IRequestHandler<SaveCouponCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCouponCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveCouponCommand request, CancellationToken cancellationToken)
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

            Coupon entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Coupons.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Coupon();
                _dbContext.Coupons.Add(entity);
            }

            entity.CampaignId = request.Data.CampaignId;
            entity.Code = request.Data.Code;
            entity.UsageLimit = request.Data.UsageLimit;
            entity.UsedCount = request.Data.UsedCount;
            entity.MinimumOrderAmount = request.Data.MinimumOrderAmount;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
