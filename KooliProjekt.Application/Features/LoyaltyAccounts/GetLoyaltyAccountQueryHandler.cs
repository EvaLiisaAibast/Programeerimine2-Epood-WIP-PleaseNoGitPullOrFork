using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class GetLoyaltyAccountQueryHandler : IRequestHandler<GetLoyaltyAccountQuery, LoyaltyAccount>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetLoyaltyAccountQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoyaltyAccount> Handle(GetLoyaltyAccountQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.LoyaltyAccounts.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
