using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Orders
{
    public class ListOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
