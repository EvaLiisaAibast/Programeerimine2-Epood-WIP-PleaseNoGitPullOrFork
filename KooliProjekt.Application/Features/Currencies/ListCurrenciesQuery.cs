using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Currencies
{
    public class ListCurrenciesQuery : IRequest<IEnumerable<Currency>>
    {
    }
}
