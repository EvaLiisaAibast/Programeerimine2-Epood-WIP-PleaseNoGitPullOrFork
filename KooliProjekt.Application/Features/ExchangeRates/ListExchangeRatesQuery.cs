using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class ListExchangeRatesQuery : IRequest<OperationResult<PagedResult<ExchangeRateListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
