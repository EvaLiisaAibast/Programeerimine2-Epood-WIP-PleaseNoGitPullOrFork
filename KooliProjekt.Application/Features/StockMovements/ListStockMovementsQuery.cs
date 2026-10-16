using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.StockMovements
{
    public class ListStockMovementsQuery : IRequest<IEnumerable<StockMovement>>
    {
    }
}
