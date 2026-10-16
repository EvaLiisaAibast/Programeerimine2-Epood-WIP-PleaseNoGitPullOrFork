using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class ListLoyaltyAccountsQueryHandler : IRequestHandler<ListLoyaltyAccountsQuery, IEnumerable<LoyaltyAccount>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListLoyaltyAccountsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LoyaltyAccount>> Handle(ListLoyaltyAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.LoyaltyAccounts.ToListAsync(cancellationToken);

            return result;
        }
    }
}
