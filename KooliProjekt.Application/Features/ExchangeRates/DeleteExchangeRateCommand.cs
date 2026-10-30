using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class DeleteExchangeRateCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
