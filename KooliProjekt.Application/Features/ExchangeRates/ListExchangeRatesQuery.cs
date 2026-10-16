using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ExchangeRates
{
    public class ListExchangeRatesQuery : IRequest<IEnumerable<ExchangeRate>>
    {
    }
}
