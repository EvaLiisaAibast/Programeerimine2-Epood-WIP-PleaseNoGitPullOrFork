using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class GetExchangeRateQueryHandler : IRequestHandler<GetExchangeRateQuery, OperationResult<ExchangeRateDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetExchangeRateQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ExchangeRateDto>> Handle(GetExchangeRateQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ExchangeRateDto>();

            response.Value = await _dbContext.ExchangeRates
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new ExchangeRateDto
                {
                    Id = x.Id,
                    FromCurrencyId = x.FromCurrencyId,
                    FromCurrencyCode = _dbContext.Currencies.Where(t => t.Id == x.FromCurrencyId).Select(t => t.Code).FirstOrDefault(),
                    ToCurrencyId = x.ToCurrencyId,
                    ToCurrencyCode = _dbContext.Currencies.Where(t => t.Id == x.ToCurrencyId).Select(t => t.Code).FirstOrDefault(),
                    Rate = x.Rate,
                    ValidFrom = x.ValidFrom,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
