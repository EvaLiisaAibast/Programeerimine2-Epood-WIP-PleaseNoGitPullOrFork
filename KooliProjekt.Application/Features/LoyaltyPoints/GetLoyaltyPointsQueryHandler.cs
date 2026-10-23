using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class GetLoyaltyPointsQueryHandler : IRequestHandler<GetLoyaltyPointsQuery, OperationResult<LoyaltyPointsDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetLoyaltyPointsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<LoyaltyPointsDto>> Handle(GetLoyaltyPointsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<LoyaltyPointsDto>();

            response.Value = await _dbContext.LoyaltyPoints
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new LoyaltyPointsDto
                {
                    Id = x.Id,
                    AccountId = x.AccountId,
                    Points = x.Points,
                    Reason = x.Reason,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
