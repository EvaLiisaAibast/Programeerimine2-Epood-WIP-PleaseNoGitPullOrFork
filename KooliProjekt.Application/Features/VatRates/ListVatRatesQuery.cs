using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.VatRates
{
    public class ListVatRatesQuery : IRequest<IEnumerable<VatRate>>
    {
    }
}
