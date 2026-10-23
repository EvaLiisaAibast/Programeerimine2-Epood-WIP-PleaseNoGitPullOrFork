using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Currencies
{
    public class ListCurrenciesQueryHandler : IRequestHandler<ListCurrenciesQuery, OperationResult<PagedResult<CurrencyListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCurrenciesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CurrencyListItemDto>>> Handle(ListCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CurrencyListItemDto>>();

            response.Value = await _dbContext.Currencies
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CurrencyListItemDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Symbol = x.Symbol,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
