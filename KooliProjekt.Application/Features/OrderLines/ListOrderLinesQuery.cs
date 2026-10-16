using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OrderLines
{
    public class ListOrderLinesQuery : IRequest<IEnumerable<OrderLine>>
    {
    }
}
