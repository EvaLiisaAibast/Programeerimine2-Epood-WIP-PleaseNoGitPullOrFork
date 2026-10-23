using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Coupons
{
    public class ListCouponsQueryHandler : IRequestHandler<ListCouponsQuery, OperationResult<PagedResult<CouponListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCouponsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CouponListItemDto>>> Handle(ListCouponsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CouponListItemDto>>();

            response.Value = await _dbContext.Coupons
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CouponListItemDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    CampaignName = _dbContext.Campaigns.Where(t => t.Id == x.CampaignId).Select(t => t.Name).FirstOrDefault(),
                    UsedCount = x.UsedCount,
                    UsageLimit = x.UsageLimit,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
