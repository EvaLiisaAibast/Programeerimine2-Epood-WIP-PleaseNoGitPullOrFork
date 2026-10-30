using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class SaveExchangeRateCommand : IRequest<OperationResult<int>>
    {
        public ExchangeRateDto Data { get; set; }
    }
}
