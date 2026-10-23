using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class ListLoyaltyPointsQueryHandler : IRequestHandler<ListLoyaltyPointsQuery, OperationResult<PagedResult<LoyaltyPointsListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListLoyaltyPointsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<LoyaltyPointsListItemDto>>> Handle(ListLoyaltyPointsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<LoyaltyPointsListItemDto>>();

            response.Value = await _dbContext.LoyaltyPoints
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new LoyaltyPointsListItemDto
                {
                    Id = x.Id,
                    AccountId = x.AccountId,
                    Points = x.Points,
                    Reason = x.Reason,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
