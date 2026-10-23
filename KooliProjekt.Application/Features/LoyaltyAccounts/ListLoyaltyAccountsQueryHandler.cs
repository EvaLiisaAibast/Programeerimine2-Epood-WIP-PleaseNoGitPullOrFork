using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class ListLoyaltyAccountsQueryHandler : IRequestHandler<ListLoyaltyAccountsQuery, OperationResult<PagedResult<LoyaltyAccountListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListLoyaltyAccountsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<LoyaltyAccountListItemDto>>> Handle(ListLoyaltyAccountsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<LoyaltyAccountListItemDto>>();

            response.Value = await _dbContext.LoyaltyAccounts
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new LoyaltyAccountListItemDto
                {
                    Id = x.Id,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    Balance = x.Balance,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
