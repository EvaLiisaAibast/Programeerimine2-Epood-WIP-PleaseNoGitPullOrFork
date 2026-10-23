using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class GetLoyaltyAccountQueryHandler : IRequestHandler<GetLoyaltyAccountQuery, OperationResult<LoyaltyAccountDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetLoyaltyAccountQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<LoyaltyAccountDto>> Handle(GetLoyaltyAccountQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<LoyaltyAccountDto>();

            response.Value = await _dbContext.LoyaltyAccounts
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new LoyaltyAccountDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    Balance = x.Balance,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
