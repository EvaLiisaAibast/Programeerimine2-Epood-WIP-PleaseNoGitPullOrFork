using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class ListExchangeRatesQueryHandler : IRequestHandler<ListExchangeRatesQuery, OperationResult<PagedResult<ExchangeRateListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListExchangeRatesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ExchangeRateListItemDto>>> Handle(ListExchangeRatesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ExchangeRateListItemDto>>();

            response.Value = await _dbContext.ExchangeRates
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new ExchangeRateListItemDto
                {
                    Id = x.Id,
                    FromCurrencyCode = _dbContext.Currencies.Where(t => t.Id == x.FromCurrencyId).Select(t => t.Code).FirstOrDefault(),
                    ToCurrencyCode = _dbContext.Currencies.Where(t => t.Id == x.ToCurrencyId).Select(t => t.Code).FirstOrDefault(),
                    Rate = x.Rate,
                    ValidFrom = x.ValidFrom,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
