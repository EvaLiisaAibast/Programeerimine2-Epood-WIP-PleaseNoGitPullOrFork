using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class GetExchangeRateQuery : IRequest<ExchangeRate>
    {
        public int Id { get; set; }
    }
}
