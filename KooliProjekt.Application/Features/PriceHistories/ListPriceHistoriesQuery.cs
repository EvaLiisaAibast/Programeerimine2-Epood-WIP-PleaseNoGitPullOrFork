using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.PriceHistories
{
    public class ListPriceHistoriesQuery : IRequest<IEnumerable<PriceHistory>>
    {
    }
}
