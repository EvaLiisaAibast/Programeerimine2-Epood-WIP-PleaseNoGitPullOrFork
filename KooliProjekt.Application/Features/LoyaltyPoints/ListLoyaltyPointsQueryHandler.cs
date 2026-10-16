using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using LoyaltyPointsEntity = KooliProjekt.Application.Data.LoyaltyPoints;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class ListLoyaltyPointsQueryHandler : IRequestHandler<ListLoyaltyPointsQuery, IEnumerable<LoyaltyPointsEntity>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListLoyaltyPointsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LoyaltyPointsEntity>> Handle(ListLoyaltyPointsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.LoyaltyPoints.ToListAsync(cancellationToken);

            return result;
        }
    }
}
