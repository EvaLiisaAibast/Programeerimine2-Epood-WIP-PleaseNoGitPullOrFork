using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Coupons
{
    public class GetCouponQueryHandler : IRequestHandler<GetCouponQuery, OperationResult<CouponDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCouponQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CouponDto>> Handle(GetCouponQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CouponDto>();

            response.Value = await _dbContext.Coupons
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CouponDto
                {
                    Id = x.Id,
                    CampaignId = x.CampaignId,
                    CampaignName = _dbContext.Campaigns.Where(t => t.Id == x.CampaignId).Select(t => t.Name).FirstOrDefault(),
                    Code = x.Code,
                    UsageLimit = x.UsageLimit,
                    UsedCount = x.UsedCount,
                    MinimumOrderAmount = x.MinimumOrderAmount,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
