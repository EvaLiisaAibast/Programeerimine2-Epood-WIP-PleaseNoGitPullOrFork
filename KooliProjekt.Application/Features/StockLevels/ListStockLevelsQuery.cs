using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.StockLevels
{
    public class ListStockLevelsQuery : IRequest<IEnumerable<StockLevel>>
    {
    }
}
