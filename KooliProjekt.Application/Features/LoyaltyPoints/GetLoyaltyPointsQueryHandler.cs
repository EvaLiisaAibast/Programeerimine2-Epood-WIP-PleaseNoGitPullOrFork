using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using LoyaltyPointsEntity = KooliProjekt.Application.Data.LoyaltyPoints;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class GetLoyaltyPointsQueryHandler : IRequestHandler<GetLoyaltyPointsQuery, LoyaltyPointsEntity>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetLoyaltyPointsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoyaltyPointsEntity> Handle(GetLoyaltyPointsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.LoyaltyPoints.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
