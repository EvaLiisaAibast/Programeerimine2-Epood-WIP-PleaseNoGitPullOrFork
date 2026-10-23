using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class GetExchangeRateQuery : IRequest<OperationResult<ExchangeRateDto>>
    {
        public int Id { get; set; }
    }
}
